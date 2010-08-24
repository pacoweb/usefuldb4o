using System;

namespace UsefulDB4O.OleDBMigration
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RelationInformationAttribute : Attribute
    {
        public string PrivateCollectionFieldName { get; set; }

        public bool IsEntityParent { get; set; }
        
        public string ParentTableName   { get; set; }
        public string ChildTableName    { get; set; }

        public string[] ParentColumnNames   { get; set; }
        public string[] ChildColumnNames    { get; set; }

        public string[] PropertyNames        { get; set; }
        public string[] ForeignFieldNames    { get; set; }
    }
}