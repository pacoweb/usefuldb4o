using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsefulDB4O.DatabaseConfig;
using Db4objects.Db4o.CS.Config;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Config.Encoding;
using System.Collections.ObjectModel;
using Example.Entities.Products;
using Db4objects.Db4o.Config;

namespace AdvancedWebApplication.Services
{
    public static class DatabasesConfiguration
    {
        public const int ProductsDefaultActivationDepth = 0;        //I want control activation depth manualy

        /// <summary>
        /// Returns IServerConfiguration for the Products database. 
        /// You have to define this method in dbo, web.config section
        /// </summary>
        /// <returns></returns>
        public static IServerConfiguration GetProductsConfiguration()
        {
            var databaseConfig = Db4oClientServer.NewServerConfiguration();

            ConfigGenerator.GetConfigFromAttributes(databaseConfig.Common,
                new Collection<Type> { typeof(Product), typeof(Category) });

            databaseConfig.Common.ActivationDepth = ProductsDefaultActivationDepth;
            databaseConfig.Common.StringEncoding = StringEncodings.Unicode();
            databaseConfig.Common.WeakReferences = false;
            
            databaseConfig.File.DisableCommitRecovery();

            return databaseConfig;
        }
    }
}