using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

using Db4objects.Db4o.CS.Config;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Config.Encoding;
using Db4objects.Db4o.Config;

using UsefulDB4O.DatabaseConfig;

namespace UsefulDB4OToWeb.ExampleEntities
{
    public static class DatabasesConfiguration
    {   
        /// <summary>
        /// Returns IServerConfiguration for the Products database. 
        /// You have to define this method in dbo, web.config section
        /// </summary>
        /// <returns></returns>
        public static IServerConfiguration GetExampleConfiguration()
        {
            var databaseConfig = Db4oClientServer.NewServerConfiguration();

            ConfigGenerator.GetConfigFromAttributes(databaseConfig.Common,
                new Collection<Type> { typeof(Product), typeof(Category) });

            databaseConfig.Common.ActivationDepth = 0; //I want control activation depth manualy
            databaseConfig.Common.StringEncoding = StringEncodings.Unicode();
            databaseConfig.Common.WeakReferences = false;
            
            databaseConfig.File.DisableCommitRecovery();

            return databaseConfig;
        }
    }
}