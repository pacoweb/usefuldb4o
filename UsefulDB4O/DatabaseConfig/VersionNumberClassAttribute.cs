﻿using System;

namespace UsefulDB4O.DatabaseConfig
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class VersionNumberClassAttribute : Attribute
    {
        public bool Generate { get; set; }
    }
}