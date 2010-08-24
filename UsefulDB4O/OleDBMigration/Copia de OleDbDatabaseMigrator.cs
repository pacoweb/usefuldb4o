using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Db4objects.Db4o;
using Db4objects.Db4o.Config.Encoding;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Defragment;
using Db4objects.Db4o.IO;

using UsefulDb4o.DatabaseConfig;
using UsefulDb4o.OleDbMigration.Attributes;
using Db4objects.Db4o.Config;
using System.Text;

namespace UsefulDb4o.OleDbMigration
{
    internal class EntityTypeInfo
    {
        internal int TotalRowsCount { get; set; }
        internal int ParentRelationsCount { get; set; }
        internal int ChildRelationsCount { get; set; }
    }
    
    public sealed class OleDbDatabaseMigrator : IDisposable
    {
        public delegate void MigratorBeforeFillEventHandler(object sender, MigratorBeforeStepEventArgs e);
        public delegate void MigratorAfterFillEventHandler(object sender, MigratorAfterStepEventArgs e);

        #region PROPERTIES

        public string DataBaseConnectionString { get; set; }
        
        public Assembly EntitiesAssembly { get; set; }
        public string EntitiesNamespaceBase { get; set; }

        public string DataBaseFilePath { get; set; }
        public string PreviousDataBaseBackupFilePath { get; set; }
        public bool JustFillItemsWithOutRelations { get; set; }
        public bool UseParallelMode { get; set; }
        public int ParallelHandlesCount { get; set; }
        public int TopRowsPerTable { get; set; }
        public bool UseMemoryStorage { get; set; }
        public int EntitiesStorePool { get; set; }
        public bool UseDefragmentInProcess { get; set; }

        public event MigratorBeforeFillEventHandler StepBeforeFilled;
        public event MigratorAfterFillEventHandler StepAfterFilled;

        #endregion

        #region PRIVATE MEMBERS

        private bool _disposed;
        private Dictionary<Type, EntityTypeInfo> _entitityTypes;
        private bool _isDb4OInitiated;

        private IObjectServer _emmbededServer;
        private IEmbeddedObjectContainer _embeddedContainer;

        private const bool UseClient = true;

        #endregion

        public void Start()
        {
            const string propertyMissingFormat = "The property {0} is required for the Init method in Db4oDatabaseGenerator";

            if (String.IsNullOrEmpty(DataBaseConnectionString))
                throw new Exception(String.Format(propertyMissingFormat, "DataBaseConnectionString"));

            if (String.IsNullOrEmpty(EntitiesNamespaceBase))
                throw new Exception(String.Format(propertyMissingFormat, "EntitiesNamespaceBase"));

            if (EntitiesAssembly == null)
                throw new Exception(String.Format(propertyMissingFormat, "EntitiesAssembly"));

            if (String.IsNullOrEmpty(DataBaseFilePath))
                throw new Exception(String.Format(propertyMissingFormat, "DataBaseFilePath"));

            var types = EntitiesAssembly.GetTypes()
                                 .Where(tp => tp.FullName.StartsWith(EntitiesNamespaceBase)
                                                && tp.GetAttribute<TableInformationAttribute>() != null)
                                 .ToList();

            if (types == null || types.Count == 0)
                throw new Exception(String.Format("There aren´t types in this namespace '{0}'", EntitiesNamespaceBase));

            _entitityTypes = new Dictionary<Type, EntityTypeInfo>(types.Count);

            foreach (Type type in types){
                    _entitityTypes.Add(type, new EntityTypeInfo());
            }

            _isDb4OInitiated = false;

            EnsureDb4OEmbeddedServer(true, false);

            FillAllEntities();

            if (!UseMemoryStorage)
            {
                CloseDb4OContainer();

                if(UseDefragmentInProcess)
                    DefragFileDataBase();
            }

            if (!JustFillItemsWithOutRelations)
            {
                EnsureDb4OEmbeddedServer(false, false);
                FillRelationsBetweenEntities();
            }

            if (UseMemoryStorage)
                CopyToFileDataBase();
            else
            {
                CloseDb4OContainer();

                if (UseDefragmentInProcess)
                    DefragFileDataBase();
            }
        }

        #region PRIVATE STATIC METHODS

        private int FillEntity(Type entityType, string oledbConnectionString, IObjectContainer db4OContainer, int topRows)
        {
            var tableAttrib = entityType.GetAttribute<TableInformationAttribute>();

            if (tableAttrib == null)
                return 0;

            var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.GetAttribute<ColumnInformationAttribute>() != null)
                    .ToList();

            if (properties.Count == 0)
                return 0;

            var columnList = properties.Select(
                    prop => prop.GetAttribute<ColumnInformationAttribute>().ColumnName).ToList();

            var select = MigratorUtilities.GetSelectProvider(oledbConnectionString).GetSqlQuery(tableAttrib.TableName, columnList, topRows);

            return MigratorUtilities.AddOledbRowsToEntity(entityType, select, properties, oledbConnectionString, db4OContainer);
        }

        private void FillRelationsOfEntity(Type entityType, IObjectContainer db4OContainer, int poolCount)
        {
            var relations = MigratorUtilities.GetRelationsOfEntity(entityType);

            if (relations == null || relations.Count == 0)
                return;

            var properties      = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            var fields          = entityType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var entityQuery = db4OContainer.Query();
            entityQuery.Constrain(entityType);

            var entityList      = entityQuery.Execute().ToList<object>(db4OContainer, 1);
            var entityListCount = entityList == null ? 0 : entityList.Count;

            if (entityListCount == 0)
                return;

            var entityTempCount = 0;

            var blder = new StringBuilder();

            foreach (var entity in entityList)
            {

                //foreach (var relation in relations)
                //{
                //    var propertyAttrib  = relation.Key;
                //    var relAttrib       = relation.Value;

                //    if (!relAttrib.IsEntityParent)
                //    {
                //        #region FIND AND SET PARENT PROPERTY

                //        var parentQuery = db4OContainer.Query();
                //        parentQuery.Constrain(propertyAttrib.PropertyType);


                //        var colsCount = relAttrib.ParentColumnNames.Count();

                //        for (var i = 0; i < colsCount; i++)
                //        {
                //            var propertyName    = relAttrib.PropertyNames[i];
                //            var foreigFieldName = relAttrib.ForeignFieldNames[i];

                //            var propertyInfo  = properties.Single(prop => prop.Name.Equals(propertyName));
                //            var propertyValue = propertyInfo.GetValue(entity, null);

                //            parentQuery.Descend(foreigFieldName).Constrain(propertyValue).Equal();
                //        }

                //        var parent = parentQuery.Execute().ToList<object>(db4OContainer, 1).SingleOrDefault();

                //        if (parent == null)
                //            continue;

                //        propertyAttrib.SetValue(entity, parent, null); 

                //        #endregion
                //    }
                //    else
                //    {
                //        #region FIND CHILD PROPERTIES

                //        var collectionType  = propertyAttrib.PropertyType.GetGenericTypeDefinition();
                //        var collectionField = fields.Single(fl => fl.Name.Equals(relAttrib.PrivateCollectionFieldName));
                //        var childType       = propertyAttrib.PropertyType.GetGenericArguments()[0];

                //        var childQuery = db4OContainer.Query();

                //        childQuery.Constrain(childType);

                //        var colsCount = relAttrib.ChildColumnNames.Count();

                //        for (var i = 0; i < colsCount; i++)
                //        {
                //            var propertyName    = relAttrib.PropertyNames[i];
                //            var foreigFieldName = relAttrib.ForeignFieldNames[i];

                //            var propertyInfo = properties.Single(prop => prop.Name.Equals(propertyName));
                //            var propertyValue = propertyInfo.GetValue(entity, null);

                //            childQuery.Descend(foreigFieldName).Constrain(propertyValue).Equal();
                //        }

                //        var childs = childQuery.Execute().ToList<object>(db4OContainer, 1);

                //        if (childs == null || childs.Count == 0)
                //            continue;

                //        var constructedType = collectionType.MakeGenericType(childType);
                //        var childCollection = Activator.CreateInstance(constructedType);
                //        var addMehod = childCollection.GetType().GetMethod("Add");

                //        foreach (var child in childs)
                //            addMehod.Invoke(childCollection, new[] { child });

                //        collectionField.SetValue(entity, childCollection);

                //        #endregion
                //    }
                //}


                if (entityType.ToString().Contains("CreditCard"))
                {
                    try
                    {
                        db4OContainer.Store(entity);
                        db4OContainer.Ext().Purge(entity);
                        db4OContainer.Commit();
                    }
                    catch (Exception excep)
                    {
                        blder.AppendLine(excep.Message);
                    }
                }

                entityTempCount++;

                //if (entityTempCount == poolCount)
                //{
                //    db4OContainer.Commit();
                //    entityTempCount = 0;
                //}
            }

            //if(entityTempCount > 0)
            //    db4OContainer.Commit();

        }

        #endregion

        #region PRIVATE METHODS

        private int EntityTypesCount()
        {
            return _entitityTypes == null ? 0 : _entitityTypes.Count;
        }

        private void OnStepBeforeFilled(Type entityType, MigrationStep step, DateTime startTime)
        {
            if (StepBeforeFilled != null)
                StepBeforeFilled(this, new MigratorBeforeStepEventArgs
                {
                    AllTypesCount = EntityTypesCount(),
                    CurrentEntity = entityType,
                    Step = step,
                    StartTime = startTime
                });
        }

        private void OnStepAfterFilled(Type entityType, MigrationStep step, DateTime startTime, DateTime endTime)
        {
            if (StepAfterFilled != null)
                StepAfterFilled(this, new MigratorAfterStepEventArgs
                                          {
                    AllTypesCount = EntityTypesCount(),
                    CurrentEntity = entityType,
                    Step = step,
                    StartTime = startTime,
                    EndTime = endTime
                });
        }

        private void EnsureDb4OEmbeddedServer(bool deletePreviousFile, bool weakReferences)
        {
            if (_isDb4OInitiated)
                return;

            if (deletePreviousFile && File.Exists(DataBaseFilePath))
            {
                var fileName    = Path.GetFileNameWithoutExtension(DataBaseFilePath);
                var folderPath  = Path.GetDirectoryName(DataBaseFilePath);

                File.Move(DataBaseFilePath,
                          String.IsNullOrEmpty(PreviousDataBaseBackupFilePath)
                              ? Path.Combine(folderPath, fileName + DateTime.Now.ToString("yyMMddHHmmss"))
                              : PreviousDataBaseBackupFilePath);

                File.Delete(DataBaseFilePath);
            }

            if (UseClient)
            {
                var clientConfig = Db4oEmbedded.NewConfiguration();

                SetCommonConfiguration(clientConfig.Common, weakReferences);

                if (UseMemoryStorage)
                    clientConfig.File.Storage = new PagingMemoryStorage();

                _embeddedContainer = Db4oEmbedded.OpenFile(clientConfig, DataBaseFilePath);
            }
            else
            {
                var serverConfig = Db4oClientServer.NewServerConfiguration();

                SetCommonConfiguration(serverConfig.Common, weakReferences);

                if (UseMemoryStorage)
                    serverConfig.File.Storage = new PagingMemoryStorage();

                _emmbededServer = Db4oClientServer.OpenServer(serverConfig, DataBaseFilePath, 0);
            }

            _isDb4OInitiated = true;
        }

        private void FillRelationsBetweenEntities()
        {
            var types = _entitityTypes
                                .OrderByDescending(kv => kv.Value.TotalRowsCount)
                                .Select(kv => kv.Key)
                                .ToList();     
            
            if (!UseParallelMode)
            {
                var blder = new StringBuilder();

                var db4OClient = UseClient ? _embeddedContainer : _emmbededServer.OpenClient();

                foreach (var entityType in types)
                {
                    var startTime = DateTime.Now;

                    OnStepBeforeFilled(entityType, MigrationStep.FillingRelations, startTime);
                    
                    try
                    {
                        FillRelationsOfEntity(entityType, db4OClient, EntitiesStorePool);
                    }
                    catch(Exception excp)
                    {
                        db4OClient.Rollback();
                        blder.AppendLine(entityType.ToString() + " " + excp.Message);
                    }

                    OnStepAfterFilled(entityType, MigrationStep.FillingRelations, startTime, DateTime.Now);
                }
 
                db4OClient.Close();
                db4OClient.Dispose();

                return;
            }

            types.EachParallel(delegate(Type entityType)
                {
                    var db4OParallelClient = UseClient ? _embeddedContainer : _emmbededServer.OpenClient();

                    var startTime = DateTime.Now;
                    OnStepBeforeFilled(entityType, MigrationStep.FillingRelations, startTime);
                    FillRelationsOfEntity(entityType, db4OParallelClient, EntitiesStorePool);
                    OnStepAfterFilled(entityType, MigrationStep.FillingRelations, startTime, DateTime.Now);

                    db4OParallelClient.Close();
                    db4OParallelClient.Dispose();

                }, ParallelHandlesCount
            );

        }

        private void FillAllEntities()
        {
            var types = _entitityTypes
                            .Select(kv => kv.Key)
                            .ToList();
            
            if (!UseParallelMode)
            {
                var db4OClient = UseClient ? _embeddedContainer : _emmbededServer.OpenClient();

                foreach (var entityType in types)
                {
                    var entityInfo = _entitityTypes[entityType];

                    var startTime = DateTime.Now;
                    OnStepBeforeFilled(entityType, MigrationStep.FillingTables, startTime);

                    entityInfo.TotalRowsCount = FillEntity(entityType, 
                            DataBaseConnectionString, db4OClient, TopRowsPerTable);

                    db4OClient.Commit();

                    OnStepAfterFilled(entityType, MigrationStep.FillingTables, startTime, DateTime.Now);
                }

                if (!UseClient)
                {
                    db4OClient.Close();
                    db4OClient.Dispose();
                }

                return;
            }

            var db4OParallelClient = _emmbededServer.OpenClient();

            types.EachParallel(entityType =>
            {
                var entityInfo = _entitityTypes[entityType];

                var startTime = DateTime.Now;
                OnStepBeforeFilled(entityType, MigrationStep.FillingTables, startTime);

                entityInfo.TotalRowsCount = FillEntity(entityType,
                            DataBaseConnectionString, db4OParallelClient, TopRowsPerTable);

                db4OParallelClient.Commit();

                OnStepAfterFilled(entityType, MigrationStep.FillingTables, startTime, DateTime.Now);

            }, ParallelHandlesCount
            );

            db4OParallelClient.Close();
            db4OParallelClient.Dispose();
        }

        private void CopyToFileDataBase()
        {
            if (!UseMemoryStorage)
                return;
            
            var containerExt = _emmbededServer.Ext().ObjectContainer().Ext();
            
            containerExt.Backup(new FileStorage(), DataBaseFilePath);

            DefragFileDataBase();
        }

        private void SetCommonConfiguration(ICommonConfiguration configuration, bool weakReferences)
        {
            ConfigGenerator.GetConfigFromAttributes(configuration, _entitityTypes.
                                                  Select(kv => kv.Key).ToList());

            configuration.ActivationDepth   = 0;
            configuration.StringEncoding    = StringEncodings.Unicode();
            configuration.WeakReferences    = weakReferences;
            configuration.WeakReferenceCollectionInterval = 1000;
        }

        private void DefragFileDataBase()
        {
            CloseDb4OContainer();
            
            var clientConfig = Db4oEmbedded.NewConfiguration();
            SetCommonConfiguration(clientConfig.Common, false);

            var defragConfig = new DefragmentConfig(DataBaseFilePath);
            defragConfig.Db4oConfig(clientConfig);
            defragConfig.ForceBackupDelete(true);

            Defragment.Defrag(defragConfig);
        }

        private void CloseDb4OContainer()
        {
            if (!UseClient && _emmbededServer == null)
                return;

            if (UseClient && _embeddedContainer == null)
                return;

            if (!UseClient)
            {
                _emmbededServer.Close();
                _emmbededServer.Dispose();
                _emmbededServer = null;
            }
            else
            {
                _embeddedContainer.Close();
                _embeddedContainer.Dispose();
                _embeddedContainer = null;
            }

            _isDb4OInitiated = false;
        }

        #endregion

        #region DISPOSING METHODS

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        public void Dispose(bool disposing) 
        {
            if (_disposed)
                return;

            if (disposing)
            {
                CloseDb4OContainer();
            }

            _emmbededServer    = null;
            _embeddedContainer = null;

            _disposed = true;
        }

        ~OleDbDatabaseMigrator()
        {
            Dispose (false);
        }

        #endregion
    }
}
