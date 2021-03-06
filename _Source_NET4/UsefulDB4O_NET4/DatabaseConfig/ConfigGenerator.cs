﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

using Db4objects.Db4o.Config;
using Db4objects.Db4o.Constraints;


namespace UsefulDB4O.DatabaseConfig
{
    public static class ConfigGenerator
    {
        /// <summary>
        /// Gets the config from attributes.
        /// </summary>
        /// <param name="commonConfig">The common config.</param>
        /// <param name="entityTypes">The entity types.</param>
        public static void GetConfigFromAttributes(ICommonConfiguration commonConfig, Collection<Type> entityTypes)
        {
            if (entityTypes == null || entityTypes.Count == 0)
                return;

            if (commonConfig == null)
                return;

            commonConfig.MarkTransient(typeof(TransientFieldAttribute).FullName);

            foreach (var entityType in entityTypes)
            {
                var objectClass = commonConfig.ObjectClass(entityType);

                var uuidAttrib = entityType.GetAttribute<UuidClassAttribute>();
                if (uuidAttrib != null)
                    objectClass.GenerateUUIDs(true);

                var versionAttrib = entityType.GetAttribute<VersionNumberClassAttribute>();
                if (versionAttrib != null)
                    objectClass.GenerateVersionNumbers(true);

                var fields = entityType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(prop => prop.GetCustomAttributes(typeof(IndexedFieldAttribute), false).Length > 0
                                || prop.GetCustomAttributes(typeof(UniqueFieldValueConstraintAttribute), false).Length > 0
                    ).ToList();

                if (fields.Count == 0)
                    continue;

                foreach (var field in from field in fields
                                      let indexAttrib = field.GetAttribute<IndexedFieldAttribute>()
                                      where indexAttrib != null
                                      select field)
                {
                    objectClass.ObjectField(field.Name).Indexed(true);

                    //No UniqueFieldValue WithOut Indexed
                    var uniqueAttrib = field.GetAttribute<UniqueFieldValueConstraintAttribute>();

                    if (uniqueAttrib != null)
                        commonConfig.Add(new UniqueFieldValueConstraint(entityType, field.Name));
                }
            }
        }
    }
}
