namespace UsefulDB4O.OleDBMigration
{
    public interface ISelectProvider
    {
        string GetSqlQuery(string tableName, string[] columnNames, int topRows);
    }
}
