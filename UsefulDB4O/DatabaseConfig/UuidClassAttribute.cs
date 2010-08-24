using System;

namespace UsefulDB4O.DatabaseConfig
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class UuidClassAttribute : Attribute
    {
        public bool Generate { get; set; }
    }
}