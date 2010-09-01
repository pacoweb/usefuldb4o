using System;
using System.Data.OleDb;

namespace UsefulDB4O.OleDBMigration
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ColumnInformationAttribute : Attribute
    {
        
        public string ColumnName { get; set; }

        public Type CodeType { get; set; }
        public OleDbType ColumnType { get; set; }
        public string CodeTypeString { get; set; }

        public bool IsPrimaryKey { get; set; }  
    }
}