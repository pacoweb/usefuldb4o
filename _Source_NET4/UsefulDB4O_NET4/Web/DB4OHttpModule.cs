using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.CS.Config;
using Db4objects.Db4o.Events;
using Db4objects.Db4o.Ext;

using UsefulDB4O.ApplicationConfig;
using UsefulDB4O.EntityInfo;

namespace UsefulDB4O.Web
{
	public sealed class DB4OHttpModule : IHttpModule
	{
		#region Private members
		
		public const string Db4OHttpModuleTypeName          = "DB4OHttpModule";
		
		private const string ClientContainerContextSufixID  = "DB4OContainer";
		private const int Embeddedportserver = 0;

		private static readonly object _thisLock = new object();

		private DataBasesRepository _repository;

		#endregion

        /// <summary>
        /// Inits the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
		public void Init(HttpApplication application)
		{
			if (application == null)
				return;

			_repository = DataBasesRepository.GetInstance();

			if (_repository.ExternalDisposeAction == null){
				_repository.ExternalDisposeAction = (rep) => CloseAllDataBases();
			}

			application.BeginRequest += ApplicationBeginRequest;
			application.EndRequest   += ApplicationEndRequest;
			application.Error        += ApplicationError;
		}

		#region INTERNAL METHODS

		internal IObjectContainer GetContainer(string databaseAlias, HttpContext context)
		{
			if (String.IsNullOrEmpty(databaseAlias))
				throw new ArgumentNullException("databaseAlias");

			if (context == null)
				throw new ArgumentNullException("context");

			var completeContextClientId = GetCompleteCurrentClientId(databaseAlias);
			var currentClient = context.Items[completeContextClientId] as IObjectContainer;

			if (currentClient != null)
			{
				Debug.WriteLine(String.Format("GetContainer (database: {0}) from Context.Items", databaseAlias));

				return currentClient;
			}

			var dataBaseData = DB4OConfigSection.GetInstance().Databases.GetDatabase(databaseAlias);

			if (dataBaseData == null)
				return null;

			currentClient = GetContainerFromConfig(dataBaseData, context);

			context.Items.Add(completeContextClientId, currentClient);

			return currentClient;
		}

		#endregion

		#region PRIVATE METHODS

		//Server/Database Staff
		private void CloseAllDataBases()
		{
			if (!_repository.AnyDataBase())
				return;

			Debug.WriteLine("CloseAllDataBases");

			lock (_thisLock)
			{
				foreach (var alias in _repository.GetDataBasesKeys())
					CloseDataBase(alias.ToString());

				_repository.EmptyDataBases();
			}
		}

		private void CloseDataBase(string alias)
		{
			if (!_repository.AnyDataBase())
				return;

			var database = _repository.GetDataBase<IObjectServer>(alias);

			if (database == null)
				return;

			database.Close();

			Debug.WriteLine(String.Format("CloseDataBase (database : {0})", alias));
		}

		private IObjectServer GetEmbeddedServer(DB4ODatabaseElement dataBaseData, int retries, HttpContext context)
		{
			IObjectServer database;

			var databaseAlias = dataBaseData.Alias;

			if (_repository.AnyDataBase())
			{
				database = _repository.GetDataBase<IObjectServer>(databaseAlias);

				if (database != null)
				{
					Debug.WriteLine(String.Format("GetEmbeddedServer ({0}, retry {1}) return cached database from repository", dataBaseData.Alias, retries));

					return database;
				}
			}

			if (dataBaseData.ServerType == Db4oServerType.NetworkingServer)
				throw new Exception(String.Format("The server '{0}' is remote and you can´t get a instance of this server", databaseAlias));

			lock (_thisLock)
			{
				var serverConfig = Db4oClientServer.NewServerConfiguration();

				if (dataBaseData.ExistAnyCustomConfiguration())
					serverConfig = dataBaseData.GetServerConfig<IServerConfiguration>();

				try
				{
					database = Db4oClientServer.OpenServer(
						serverConfig, GetAbsolutePath(dataBaseData.FileDb4oPath, context), Embeddedportserver);
				}
				catch (DatabaseFileLockedException)
				{
					if (retries < dataBaseData.OpenServerRetries)
					{
						Debug.WriteLine(String.Format("DatabaseFileLockedException (database: {1}) retry {0}", retries, dataBaseData.Alias));

						return GetEmbeddedServer(dataBaseData, retries + 1, context);
					}

					throw;
				}

				_repository.AddDataBase(databaseAlias, database);

				Debug.WriteLine(String.Format("AddDataBase (database: '{0}') to Repository", dataBaseData.Alias));
			}

			return database;
		}

		//Container/Client Staff

		private IObjectContainer GetContainerFromConfig(DB4ODatabaseElement dataBaseData, HttpContext context)
		{
			
			Debug.WriteLine(String.Format("GetContainerFromConfig (database: {0})", dataBaseData.Alias));

			IObjectContainer container;

			switch (dataBaseData.ServerType)
			{

				case Db4oServerType.NetworkingServer:

					var clientConfig = Db4oClientServer.NewClientConfiguration();

					if (dataBaseData.ExistAnyCustomConfiguration())
						clientConfig = dataBaseData.GetServerConfig<IClientConfiguration>();

					container = Db4oClientServer.OpenClient(clientConfig, dataBaseData.RemoteHost, dataBaseData.RemotePort,
						dataBaseData.RemoteUser, dataBaseData.RemotePassWord);

					break;
				case Db4oServerType.EmbeddedServer:
				default:

					var server = GetEmbeddedServer(dataBaseData, 0, context);
					container = server.OpenClient();

					break;
			}

			BindContainerEvents(container, dataBaseData);

			return container;
		}

		private static void BindContainerEvents(IObjectContainer container, DB4ODatabaseElement dataBaseData)
		{

			Debug.WriteLine(String.Format("BindingContainerEvents (database: {0})", dataBaseData.Alias));

			var eventRegistry = EventRegistryFactory.ForObjectContainer(container);

			eventRegistry.Activated += (sender, e) =>
			{
				if (e.Object == null || !dataBaseData.FillIDB4OEntityInfo)
					return;
				
				var entityInfo = e.Object as IDB4OEntityInfo;

				if (entityInfo == null)
					return;

				if (entityInfo.HasDB4OEntityInfo())
					return;

				entityInfo.FillDB4OInfo(e.ObjectContainer(), dataBaseData.FillMode);

				Debug.WriteLine(String.Format("FilledDB4OInfo (database {0})", dataBaseData.Alias));
			};

		}

		private void OpenContainersIfMandatory(HttpContext context)
		{
			var dataBases = DB4OConfigSection.GetInstance().Databases;

			if (dataBases == null || dataBases.Count == 0)
				return;

			foreach (DB4ODatabaseElement database in dataBases)
			{
				if (!database.OpenContainerOnBeginRequest)
					continue;

				GetContainer(database.Alias, context);
			}
		}

		private static void CloseContainer(string key, HttpContext context)
		{
			var client = context.Items[key] as IObjectContainer;

			if (client == null)
				return;

			if (!client.Ext().IsClosed())
			{
				client.Commit();
				client.Close();
			}

			Debug.WriteLine(String.Format("ClosedContainer (key:{0})", key));
		}

		private static void CloseAndDisposeAllContainers(HttpContext context)
		{
			var listOfContextClients = context.Items.Keys
										.OfType<String>()
										.Where(s => s.EndsWith(ClientContainerContextSufixID, StringComparison.Ordinal))
										.ToList();

			foreach (var key in listOfContextClients)
			{
				CloseContainer(key, context);
				context.Items.Remove(key);
			}
		}

		//Methods utils
		private static string GetAbsolutePath(string databaseFilePath, HttpContext context)
		{
			if (String.IsNullOrEmpty(databaseFilePath))
				throw new ArgumentNullException(databaseFilePath);

			if (Regex.IsMatch(databaseFilePath.Trim(), "^[~|/]"))
				return context.Server.MapPath(databaseFilePath.Trim().TrimStart('/'));

			return databaseFilePath;
		}

		private static string GetCompleteCurrentClientId(string databaseAlias)
		{
			return String.Format("{0}_{1}", databaseAlias, ClientContainerContextSufixID);
		}

		#endregion

		#region EVENT HANDLERS

		private void ApplicationBeginRequest(object sender, EventArgs e)
		{
			Debug.WriteLine("ApplicationBeginRequest - OpenContainersIfMandatory");

			OpenContainersIfMandatory(HttpContext.Current);
		}

		private void ApplicationError(object sender, EventArgs e)
		{
			Debug.WriteLine("ApplicationError - CloseAndDisposeAllContainers");

			CloseAndDisposeAllContainers(HttpContext.Current);
		}

		private void ApplicationEndRequest(object sender, EventArgs e)
		{
			Debug.WriteLine("ApplicationEndRequest - CloseAndDisposeAllContainers");

			CloseAndDisposeAllContainers(HttpContext.Current);
		}
 
		#endregion

		#region DISPOSING METHODS

		public void Dispose() 
		{

		}

		#endregion

	}
}
