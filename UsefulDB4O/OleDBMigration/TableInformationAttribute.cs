using System;

namespace UsefulDB4O.OleDBMigration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class TableInformationAttribute : Attribute
    {
        
        public string TableName { get; set; }

    }
}