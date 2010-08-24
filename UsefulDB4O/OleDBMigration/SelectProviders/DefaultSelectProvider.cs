using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace UsefulDB4O.OleDBMigration.SelectProviders
{
    public class DefaultSelectProvider : ISelectProvider
    {
        #region Miembros de ISelectProvider

        public string GetSqlQuery(string tableName, string[] columnNames, int topRows)
        {
            var blderSql = new StringBuilder();

            blderSql.Append("SELECT ");

            if (topRows > 0)
                blderSql.AppendFormat(" TOP {0}", topRows);

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
