using System.Text;
using System;

namespace UsefulDB4O.OleDBMigration.SelectProviders
{
    public class SqlServerSqlQueryProvider : ISelectProvider
    {
        #region Miembros de ISelectProvider

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
                blderSql.AppendFormat(!start ? ", [{0}]" : "[{0}]", columnName);

                start = false;
            }

            blderSql.Append(" FROM ");

            var parts = tableName.Split('.');

            if(parts.Length == 1)
                blderSql.AppendFormat("[{0}]", parts[0]);
            else
                blderSql.AppendFormat("[{0}].[{1}]", parts[0], parts[1]);

            return blderSql.ToString();
        }

        #endregion
    }
}
