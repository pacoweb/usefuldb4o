using System;

namespace UsefulDB4O.DatabaseConfig
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public sealed class IndexedFieldAttribute : Attribute
    {
        
    }
}