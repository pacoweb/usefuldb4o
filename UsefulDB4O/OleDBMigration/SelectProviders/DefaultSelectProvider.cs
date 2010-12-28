using System;
using System.Text;

namespace UsefulDB4O.OleDBMigration.SelectProviders
{
    public class DefaultSelectProvider : ISelectProvider
    {
        #region Miembros de ISelectProvider

        /// <summary>
        /// Gets the SQL query for default provider
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnNames">The column names.</param>
        /// <param name="topRows">The top rows.</param>
        /// <returns></returns>
        public string GetSqlQuery(string tableName, string[] columnNames, int topRows)
        {
            if (String.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            if (columnNames == null || columnNames.Length == 0)
                throw new ArgumentNullException("columnNames");
            
            var blderSql = new StringBuilder();

            blderSql.Append("SELECT ");

            if (topRows > 0)
                blderSql.AppendFormat(" TOP {0} ", topRows);

            var start = true;

            foreach (var columnName in columnNames)
            {
                blderSql.AppendFormat(!start ? ", {0}" : "{0}", columnName);
                start = false;
            }

            blderSql.AppendFormat(" FROM {0}", tableName);

            return blderSql.ToString();
        }

        #endregion
    }
}
