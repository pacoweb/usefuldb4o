using System;
using System.Collections.ObjectModel;

namespace UsefulDB4O.OleDBMigration
{
    public class MigratorGettingTypesToLoadEventArgs : EventArgs
    {
        public Collection<Type> EntityTypes { get; set; }
    }
}
