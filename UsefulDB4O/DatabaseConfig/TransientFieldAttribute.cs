using System;

namespace UsefulDB4O.DatabaseConfig
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public sealed class TransientFieldAttribute : Attribute
    {
    }
}