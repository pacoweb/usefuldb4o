using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Constraints;
using UsefulDB4O.DatabaseConfig;
using System.Collections.ObjectModel;

namespace UsefulDB4O.DatabaseConfig
{
    public static class ConfigGenerator
    {
        public static void GetConfigFromAttributes(ICommonConfiguration commonConfig, Collection<Type> entityTypes)
        {
            if (entityTypes == null || entityTypes.Count == 0)
                return;

            if (commonConfig == null)
                return;

            foreach (var entityType in entityTypes)
            {
                var objectClass = commonConfig.ObjectClass(entityType);

                var uuidAttrib = entityType.GetAttribute<UuidClassAttribute>();
                if (uuidAttrib != null)
                    objectClass.GenerateUUIDs(uuidAttrib.Generate);

                var versionAttrib = entityType.GetAttribute<VersionNumberClassAttribute>();
                if (versionAttrib != null)
                    objectClass.GenerateVersionNumbers(versionAttrib.Generate);

                var fields = entityType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(prop => prop.GetCustomAttributes(typeof(IndexedFieldAttribute), false).Length > 0
                                || prop.GetCustomAttributes(typeof(UniqueFieldValueConstraintAttribute), false).Length > 0
                    ).ToList();

                if (fields.Count == 0)
                    continue;

                foreach (var field in fields)
                {
                    var indexAttrib = field.GetAttribute<IndexedFieldAttribute>();

                    if (indexAttrib != null)
                    {
                        
                        objectClass.ObjectField(field.Name).Indexed(indexAttrib.IndexField);

                        if (!indexAttrib.IndexField)
                            continue;

                        //No UniqueFieldValue WithOut Indexed
                        var uniqueAttrib = field.GetAttribute<UniqueFieldValueConstraintAttribute>();

                        if (uniqueAttrib != null && uniqueAttrib.IsUnique)
                            commonConfig.Add(new UniqueFieldValueConstraint(entityType, field.Name));
                    }
                }
            }
        }
    }
}
