using System;

namespace UsefulDB4O.OleDBMigration
{
    public class MigratorLoadedTypeFromOleDBEventArgs : EventArgs
    {
        public Type EntityType { get; set; }
        public int LoadedRowsCount { get; set; }
    }
}
