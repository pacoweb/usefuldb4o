using System;

namespace UsefulDB4O.OleDBMigration
{
    public class MigratorFilledTypeRelationsEventArgs : EventArgs
    {
        public Type EntityType { get; set; }
    }
}
