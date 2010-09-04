using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace UsefulDB4O.OleDBMigration
{
    public class MigratorLoadingTypeFromOleDBEventArgs : CancelEventArgs
    {
        public Type EntityType { get; set; }
        public string SqlSelectQuery { get; set; }
        public List<PropertyInfo> EntityPropertiesToLoad { get; set; }
    }
}
