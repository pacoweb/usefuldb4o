using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace UsefulDB4O.OleDBMigration
{
    public class MigratorFillingTypeRelationsEventArgs : CancelEventArgs
    {
        public Type EntityType { get; set; }
        public Dictionary<PropertyInfo, RelationInformationAttribute> TypeRelationsToFill { get; set; }
    }
}
