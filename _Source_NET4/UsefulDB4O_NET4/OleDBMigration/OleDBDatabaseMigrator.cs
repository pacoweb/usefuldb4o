#region USINGS

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Config.Encoding;
using Db4objects.Db4o.Defragment;
using Db4objects.Db4o.IO;

using UsefulDB4O.DatabaseConfig;
using UsefulDB4O.OleDBMigration.SelectProviders;

#endregion

namespace UsefulDB4O.OleDBMigration
{
    [Serializable]
    public class OleDBDatabaseMigrator : IDisposable
    {

        #region DELEGATE AND EVENTS

        public delegate void MigratorGettingTypesToLoadEventHandler(object sender, MigratorGettingTypesToLoadEventArgs e);
        public delegate void MigratorLoadingTypeFromOleDbEventHandler(object sender, MigratorLoadingTypeFromOleDBEventArgs e);
        public delegate void MigratorLoadedTypeFromOleDbEventHandler(object sender, MigratorLoadedTypeFromOleDBEventArgs e);
        public delegate void MigratorFillingTypeRelationsEventHandler(object sender, MigratorFillingTypeRelationsEventArgs e);
        public delegate void MigratorFilledTypeRelationsEventHandler(object sender, MigratorFilledTypeRelationsEventArgs e);

        public event MigratorGettingTypesToLoadEventHandler GettingTypesToLoad;
        public event MigratorLoadingTypeFromOleDbEventHandler LoadingTypeFromOleDb;
        public event MigratorLoadedTypeFromOleDbEventHandler LoadedTypeFromOleDb;
        public event MigratorFillingTypeRelationsEventHandler FillingTypeRelations;
        public event MigratorFilledTypeRelationsEventHandler FilledTypeRelations; 

        #endregion
        
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the data base file path.
        /// </summary>
        /// <value>The data base file path.</value>
        public string Db4oDataBaseFilePath { get; set; }

        /// <summary>
        /// Gets or sets the data base connection string.
        /// </summary>
        /// <value>The data base connection string.</value>
        public string DataBaseConnectionString { get; set; }
  
        /// <summary>
        /// Gets or sets the entities assembly.
        /// </summary>
        /// <value>The entities assembly.</value>
        [XmlIgnore]
        public Assembly EntitiesAssembly { get; set; }

        /// <summary>
        /// Gets or sets the entities namespace base.
        /// </summary>
        /// <value>The entities namespace base.</value>
        public string EntitiesNamespaceBase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [just fill items with out relations].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [just fill items with out relations]; otherwise, <c>false</c>.
        /// </value>
        public bool JustFillItemsWithOutRelations { get; set; }

        /// <summary>
        /// Gets or sets the entities commit limit.
        /// </summary>
        /// <value>The entities commit limit.</value>
        public int EntitiesCommitLimit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use memory storage in process].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use memory storage in process]; otherwise, <c>false</c>.
        /// </value>
        public bool UseMemoryStorageInProcess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use defragment in process].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use defragment in process]; otherwise, <c>false</c>.
        /// </value>
        public bool UseDefragmentInProcess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use weak references in process].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use weak references in process]; otherwise, <c>false</c>.
        /// </value>
        public bool UseWeakReferencesInProcess { get; set; }

        /// <summary>
        /// Gets or sets the top rows per table.
        /// </summary>
        /// <value>The top rows per table.</value>
        public int TopRowsPerTable { get; set; }

        #endregion

        #region PRIVATE MEMBERS

        private const string PropertyMissingFormat = "The property {0} is required for the Start method in OleDBDatabaseMigrator";

        private bool _disposed;
        private Collection<Type> _entitityTypes;
        private IObjectContainer _db4OContainer;

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            ValidateProperties();

            FilterEntityTypes();

            BackupPreviousDataBaseFile();

            EnsureCloseDb4OContainer();

            LoadTypesFromOleDb();

            if (!UseMemoryStorageInProcess)
            {
                EnsureCloseDb4OContainer();

                if (UseDefragmentInProcess)
                    DefragFileDataBase();
            }

            if (!JustFillItemsWithOutRelations)
                FillRelationsBetweenEntities();

            if (UseMemoryStorageInProcess)
            {
                CopyToFileDiskDataBase();
                return;
            }

            if (UseDefragmentInProcess)
                DefragFileDataBase();
        }

        #endregion

        #region PUBLIC STATIC METHODS

        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <param name="migrator">The migrator.</param>
        /// <param name="targetFilePath">The target file path.</param>
        public static void SerializeToXml(OleDBDatabaseMigrator migrator, string targetFilePath)
        {
            if(String.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException("targetFilePath");

            StreamWriter writer      = null;
            XmlSerializer serializer;

            try
            {
                serializer = new XmlSerializer(typeof(OleDBDatabaseMigrator));
                writer = new StreamWriter(targetFilePath);

                serializer.Serialize(writer, migrator);
            }
            catch (Exception)
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }

                throw;
            }

            writer.Close();
            writer.Dispose();
        }

        /// <summary>
        /// Deserialize from XML.
        /// </summary>
        /// <param name="serializedFilePath">The serialized file path.</param>
        /// <returns></returns>
        public static OleDBDatabaseMigrator DeSerializeFromXml(string serializedFilePath)
        {

            XmlSerializer   serializer;
            FileStream      fileStream = null;
            OleDBDatabaseMigrator migrator;

            try
            {
                serializer = new XmlSerializer(typeof(OleDBDatabaseMigrator));
                fileStream = new FileStream(serializedFilePath, FileMode.Open);

                migrator = (OleDBDatabaseMigrator)serializer.Deserialize(fileStream);

                fileStream.Close();
                fileStream.Dispose();
            }
            catch (Exception)
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }

                throw;
            }

            fileStream.Close();
            fileStream.Dispose();

            return migrator;
        }

        #endregion

        #region PRIVATE METHODS

        private void LoadEntityType(Type entityType, IObjectContainer container)
        {
            var tableAttrib = entityType.GetAttribute<TableInformationAttribute>();

            if (tableAttrib == null)
                return;

            var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.GetAttribute<ColumnInformationAttribute>() != null)
                    .ToList();

            if (properties.Count == 0)
                return;

            var columnList = properties.Select(
                    prop => prop.GetAttribute<ColumnInformationAttribute>().ColumnName).ToArray();

            var select = GetSelectProvider().GetSqlQuery(tableAttrib.TableName, columnList, TopRowsPerTable);

            var loadingEventArgs = new MigratorLoadingTypeFromOleDBEventArgs
                                       { EntityType = entityType,
                                     SqlSelectQuery = select, EntityPropertiesToLoad = properties};

            OnLoadingType(loadingEventArgs);

            if (loadingEventArgs.Cancel)
                return;

            var itemsCount = AddOledbRowsToEntity(loadingEventArgs.EntityType, loadingEventArgs.SqlSelectQuery, loadingEventArgs.EntityPropertiesToLoad
                , container);

            OnLoadedType(new MigratorLoadedTypeFromOleDBEventArgs
                             { EntityType = entityType, 
                LoadedRowsCount = itemsCount });
        }

        private void FillRelationsOfEntity(Type entityType, IObjectContainer container)
        {
            var relations = GetRelationsOfEntity(entityType);

            if (relations == null || relations.Count == 0)
                return;

            var fillingEventArgs = new MigratorFillingTypeRelationsEventArgs
                                       {
                TypeRelationsToFill = relations,
                EntityType = entityType
            };

            OnFillingType(fillingEventArgs);

            if (fillingEventArgs.Cancel 
                    || (fillingEventArgs.TypeRelationsToFill== null || fillingEventArgs.TypeRelationsToFill.Count == 0 ))
                return;

            relations = fillingEventArgs.TypeRelationsToFill;

            var properties      = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            var fields          = entityType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var entityQuery = container.Query();
            entityQuery.Constrain(entityType);

            var entityList = entityQuery.Execute().ToList<object>(container, 1);
            var entityListCount = entityList == null ? 0 : entityList.Count;

            if (entityListCount == 0)
                return;

            var entityTempCount = 0;

            foreach (var entity in entityList)
            {

                foreach (var relation in relations)
                {
                    var propertyAttrib = relation.Key;
                    var relAttrib = relation.Value;

                    if (!relAttrib.IsEntityParent)
                    {
                        #region FIND AND SET PARENT PROPERTY

                        var parentQuery = container.Query();
                        parentQuery.Constrain(propertyAttrib.PropertyType);


                        var colsCount = relAttrib.ParentColumnNames.Count();

                        for (var i = 0; i < colsCount; i++)
                        {
                            var propertyName = relAttrib.PropertyNames[i];
                            var foreigFieldName = relAttrib.ForeignFieldNames[i];

                            var propertyInfo = properties.Single(prop => prop.Name.Equals(propertyName));
                            var propertyValue = propertyInfo.GetValue(entity, null);

                            parentQuery.Descend(foreigFieldName).Constrain(propertyValue).Equal();
                        }

                        var parent = parentQuery.Execute().ToList<object>(container, 1).SingleOrDefault();

                        if (parent == null)
                            continue;

                        propertyAttrib.SetValue(entity, parent, null);

                        #endregion
                    }
                    else
                    {
                        #region FIND CHILD PROPERTIES

                        var collectionType = propertyAttrib.PropertyType.GetGenericTypeDefinition();
                        var collectionField = fields.Single(fl => fl.Name.Equals(relAttrib.PrivateCollectionFieldName));
                        var childType = propertyAttrib.PropertyType.GetGenericArguments()[0];

                        var childQuery = container.Query();

                        childQuery.Constrain(childType);

                        var colsCount = relAttrib.ChildColumnNames.Count();

                        for (var i = 0; i < colsCount; i++)
                        {
                            var propertyName = relAttrib.PropertyNames[i];
                            var foreigFieldName = relAttrib.ForeignFieldNames[i];

                            var propertyInfo = properties.Single(prop => prop.Name.Equals(propertyName));
                            var propertyValue = propertyInfo.GetValue(entity, null);

                            childQuery.Descend(foreigFieldName).Constrain(propertyValue).Equal();
                        }

                        var childs = childQuery.Execute().ToList<object>(container, 1);

                        if (childs == null || childs.Count == 0)
                            continue;

                        var constructedType = collectionType.MakeGenericType(childType);
                        var childCollection = Activator.CreateInstance(constructedType);
                        var addMehod = childCollection.GetType().GetMethod("Add");

                        foreach (var child in childs)
                            addMehod.Invoke(childCollection, new[] { child });

                        collectionField.SetValue(entity, childCollection);

                        #endregion
                    }
                }

                entityTempCount++;

                if (entityTempCount != EntitiesCommitLimit) 
                    continue;
                
                container.Commit();
                entityTempCount = 0;
            }

            if(entityTempCount > 0)
                container.Commit();

            var filledEventArgs = new MigratorFilledTypeRelationsEventArgs
                                      {
                 EntityType = entityType
            };

            OnFilledType(filledEventArgs);
        }

        private void FilterEntityTypes()
        {
            var exceptionMessage = String.Format(CultureInfo.InvariantCulture, "There aren´t types in this namespace '{0}'"
                , EntitiesNamespaceBase);
            
            _entitityTypes = EntitiesAssembly
                     .GetTypes()
                     .Where(tp => tp.FullName.StartsWith(EntitiesNamespaceBase, StringComparison.OrdinalIgnoreCase)
                                    && tp.GetAttribute<TableInformationAttribute>() != null)
                     .ToCollection();
            
            if (_entitityTypes == null || _entitityTypes.Count == 0)
                throw new ArgumentNullException(exceptionMessage);

            var gettingTypesEventArgs = new MigratorGettingTypesToLoadEventArgs
                                            {
                EntityTypes = _entitityTypes
            };

            OnGettingTypesToLoad(gettingTypesEventArgs);

            if (_entitityTypes == null || _entitityTypes.Count == 0)
                throw new ArgumentNullException(exceptionMessage);
        }

        private ISelectProvider GetSelectProvider()
        {
            if (DataBaseConnectionString.IndexOf("SQLNCLI", StringComparison.OrdinalIgnoreCase) != -1)
                return new SqlServerSqlQueryProvider();

            return new DefaultSelectProvider();
        }

        private static Dictionary<PropertyInfo, RelationInformationAttribute> GetRelationsOfEntity(Type entityType)
        {
            var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .Where(prop => prop.GetAttribute<RelationInformationAttribute>() != null)
                                .ToList();

            var relations = new Dictionary<PropertyInfo, RelationInformationAttribute>();

            if (properties.Count == 0)
                return relations;

            foreach (var property in properties)
            {
                var relAttrib = property.GetAttribute<RelationInformationAttribute>();
                relations.Add(property, relAttrib);
            }

            return relations;
        }

        private int AddOledbRowsToEntity(Type entityType, string select, List<PropertyInfo> propertyList, IObjectContainer container)
        {
            var totalCount      = 0;
            var entityTempCount = 0;

            using (var oleDbConnection = new OleDbConnection(DataBaseConnectionString))
            {
                oleDbConnection.Open();

                using (var cmd = new OleDbCommand(select, oleDbConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var dataRdr = cmd.ExecuteReader())
                    {
                        if (dataRdr == null || !dataRdr.HasRows)
                            return totalCount;

                        var colsCount = dataRdr.FieldCount;
                        var values = new object[colsCount];

                        while (dataRdr.Read())
                        {
                            dataRdr.GetValues(values);

                            var entity = Activator.CreateInstance(entityType);

                            for (int i = 0; i < propertyList.Count; i++)
                            {
                                var dataValue = values[i];
                                var isNullDataValue = (dataValue == null || Convert.IsDBNull(dataValue)) ?
                                    true : false;

                                if (!isNullDataValue)
                                    propertyList[i].SetValue(entity, dataValue, null);
                            }

                            container.Store(entity);
                            container.Ext().Purge(entity);

                            entityTempCount++;

                            if (entityTempCount == EntitiesCommitLimit)
                            {
                                container.Commit();
                                entityTempCount = 0;
                            }

                            totalCount++;

                        }
                    }
                }
            }

            if (entityTempCount > 0)
                container.Commit();

            return totalCount;
        }

        private void ValidateProperties()
        {
            
            if (String.IsNullOrEmpty(DataBaseConnectionString))
                throw new ArgumentNullException(String.Format(CultureInfo.InvariantCulture, PropertyMissingFormat, "DataBaseConnectionString"));

            if (String.IsNullOrEmpty(EntitiesNamespaceBase))
                throw new ArgumentNullException(String.Format(CultureInfo.InvariantCulture, PropertyMissingFormat, "EntitiesNamespaceBase"));

            if (EntitiesAssembly == null)
                throw new ArgumentNullException(String.Format(CultureInfo.InvariantCulture, PropertyMissingFormat, "EntitiesAssembly"));

            if (String.IsNullOrEmpty(Db4oDataBaseFilePath))
                throw new ArgumentNullException(String.Format(CultureInfo.InvariantCulture, PropertyMissingFormat, "DataBaseFilePath"));

        }

        private void BackupPreviousDataBaseFile()
        {
            if (!File.Exists(Db4oDataBaseFilePath))
                return;

            var fileName    = Path.GetFileNameWithoutExtension(Db4oDataBaseFilePath);
            var newFilePath = Path.Combine(Path.GetDirectoryName(Db4oDataBaseFilePath), fileName + DateTime.Now.ToString("yyMMddHHmmss", CultureInfo.InvariantCulture));

            File.Move(Db4oDataBaseFilePath, newFilePath);
            File.Delete(Db4oDataBaseFilePath);
        }

        private void LoadTypesFromOleDb()
        {
            EnsureOpenDb4OContainer();

            var db4OClient = GetDb4OContainer();

            foreach (var entityType in _entitityTypes)
                LoadEntityType(entityType, db4OClient);
        }

        private void FillRelationsBetweenEntities()
        {
            EnsureOpenDb4OContainer();

            var db4OClient = GetDb4OContainer();

            foreach (var entityType in _entitityTypes)
                FillRelationsOfEntity(entityType, db4OClient);
        }

        private void CopyToFileDiskDataBase()
        {
            if (!UseMemoryStorageInProcess)
                return;
            
            var containerExt = GetDb4OContainer().Ext();

            containerExt.Backup(new FileStorage(), Db4oDataBaseFilePath);

            //TODO: Defrag have problems with generated file from Backup
            //Defrag says that there is not file (but File.Exists say yes)
            //if(UseDefragmentInProcess)
                //DefragFileDataBase();
        }

        private IEmbeddedConfiguration GetEmbeddedConfiguration()
        {
            var clientConfig = Db4oEmbedded.NewConfiguration();

            ConfigGenerator.GetConfigFromAttributes(clientConfig.Common, _entitityTypes);

            clientConfig.Common.ActivationDepth = 0;
            clientConfig.Common.StringEncoding = StringEncodings.Unicode();
            clientConfig.Common.WeakReferences = UseWeakReferencesInProcess;

            if (UseMemoryStorageInProcess)
                clientConfig.File.Storage = new PagingMemoryStorage();

            return clientConfig;
        }

        private void DefragFileDataBase()
        {
            EnsureCloseDb4OContainer();

            var defragConfig = new DefragmentConfig(Db4oDataBaseFilePath);
            defragConfig.Db4oConfig(GetEmbeddedConfiguration());
            defragConfig.ForceBackupDelete(true);

            Defragment.Defrag(defragConfig);
        }

        private void EnsureOpenDb4OContainer()
        {
            if (GetDb4OContainer() != null)
                return;

            _db4OContainer = Db4oEmbedded.OpenFile(GetEmbeddedConfiguration(), Db4oDataBaseFilePath);
        }

        private void EnsureCloseDb4OContainer()
        {
            if (GetDb4OContainer() == null)
                return;

            GetDb4OContainer().Close();
            GetDb4OContainer().Dispose();

            _db4OContainer = null;
        }

        private IObjectContainer GetDb4OContainer()
        {
            return _db4OContainer;
        }

        #endregion

        #region PRIVATE METHODS THAT RAISES EVENTS

        private void OnGettingTypesToLoad(MigratorGettingTypesToLoadEventArgs gettingTypesEventArgs)
        {
            if (GettingTypesToLoad == null)
                return;

            GettingTypesToLoad(this, gettingTypesEventArgs);
        }

        private void OnLoadingType(MigratorLoadingTypeFromOleDBEventArgs loadingEventArgs)
        {
            if (LoadingTypeFromOleDb == null)
                return;

            LoadingTypeFromOleDb(this, loadingEventArgs);
        }


        private void OnLoadedType(MigratorLoadedTypeFromOleDBEventArgs loadedEventArgs)
        {
            if (LoadedTypeFromOleDb == null)
                return;

            LoadedTypeFromOleDb(this, loadedEventArgs);
        }


        private void OnFillingType(MigratorFillingTypeRelationsEventArgs fillingEventArgs)
        {
            if (FillingTypeRelations == null)
                return;

            FillingTypeRelations(this, fillingEventArgs);
        }


        private void OnFilledType(MigratorFilledTypeRelationsEventArgs filledEventArgs)
        {
            if (FilledTypeRelations == null)
                return;

            FilledTypeRelations(this, filledEventArgs);
        }

        #endregion

        #region DISPOSING METHODS

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (_disposed)
                return;

            if (disposing)
            {
                EnsureCloseDb4OContainer();
            }

            _db4OContainer = null;

            _disposed = true;
        }

        ~OleDBDatabaseMigrator()
        {
            Dispose (false);
        }

        #endregion
    }
}
