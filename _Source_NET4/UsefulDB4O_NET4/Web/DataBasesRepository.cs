using System;
using System.Collections;

namespace UsefulDB4O.Web
{
    internal class DataBasesRepository : IDisposable
    {
        private Hashtable _dataBasesList;
        private bool _disposed;
        private static DataBasesRepository _repository;

        internal Action<DataBasesRepository> ExternalDisposeAction { get; set; }

        //SINGLETON
        internal static DataBasesRepository GetInstance()
        {
            return _repository ?? (_repository = new DataBasesRepository());
        }

        internal object AddDataBase(string databaseAlias, object database)
        {
            if (_dataBasesList == null)
                _dataBasesList = new Hashtable();

            _dataBasesList.Add(databaseAlias, database);

            return database;
        }

        internal bool AnyDataBase()
        {
            if (_dataBasesList == null || _dataBasesList.Count == 0)
                return false;

            return true;
        }

        internal void EmptyDataBases()
        {
            if (_dataBasesList == null || _dataBasesList.Count == 0)
                return;

            _dataBasesList.Clear();
            _dataBasesList = null;
        }

        internal object GetDataBase(string databaseAlias)
        {
            if (!AnyDataBase())
                return null;

            var database = _dataBasesList[databaseAlias];

            return database;
        }

        internal T GetDataBase<T>(string databaseAlias)
        {
            var database = GetDataBase(databaseAlias);

            if (database == null)
                return default(T);

            return (T)database;
        }

        internal ICollection GetDataBasesKeys()
        {
            if (!AnyDataBase())
                return null;

            return _dataBasesList.Keys;
        }

        #region DISPOSING METHODS

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (ExternalDisposeAction != null)
                    ExternalDisposeAction(this);
            }

            _disposed = true;
        }

        ~DataBasesRepository()
        {
            Dispose(false);
        }

        #endregion

    }
}
