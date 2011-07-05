using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using UsefulDB4O.EntityInfo;
using System.Diagnostics;

namespace UsefulDB4O.ApplicationConfig
{
    /// <summary>
    /// 
    /// </summary>
    public enum Db4oServerType
    {
        /// <summary>
        /// 
        /// </summary>
        EmbeddedServer,
        /// <summary>
        /// 
        /// </summary>
        NetworkingServer
    }

    public class DB4ODatabaseElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the type of the server.
        /// </summary>
        /// <value>The type of the server.</value>
        [ConfigurationProperty("serverType", IsRequired = true)]
        public Db4oServerType ServerType
        {
            get
            {
                var type = this["serverType"] as Db4oServerType?;

                if (!type.HasValue)
                    return Db4oServerType.EmbeddedServer;

                return type.Value;
            }
        }


        /// <summary>
        /// Gets the alias of the database
        /// </summary>
        /// <value>The alias.</value>
        [ConfigurationProperty("alias", IsRequired = true, IsKey=true)]
        public string Alias
        {
            get
            {
                return this["alias"] as string;
            }
        }

        /// <summary>
        /// Gets the remote host.
        /// </summary>
        /// <value>The remote host.</value>
        [ConfigurationProperty("remoteHost")]
        public string RemoteHost
        {
            get
            {
                return this["remoteHost"] as string;
            }
        }

        /// <summary>
        /// Gets the remote port.
        /// </summary>
        /// <value>The remote port.</value>
        [ConfigurationProperty("remotePort")]
        public int RemotePort
        {
            get
            {
                var port = this["remotePort"] as int?;

                if (!port.HasValue)
                    return 0;

                return port.Value;
            }
        }

        /// <summary>
        /// Gets the remote user.
        /// </summary>
        /// <value>The remote user.</value>
        [ConfigurationProperty("remoteUser")]
        public string RemoteUser
        {
            get
            {
                return this["remoteUser"] as string;
            }
        }

        /// <summary>
        /// Gets the remote pass word.
        /// </summary>
        /// <value>The remote pass word.</value>
        [ConfigurationProperty("remotePassWord")]
        public string RemotePassWord
        {
            get
            {
                return this["remotePassWord"] as string;
            }
        }

        /// <summary>
        /// Gets the file db4o path for the embedded server type
        /// </summary>
        /// <value>The file db4o path.</value>
        [ConfigurationProperty("fileDb4oPath")]
        public string FileDb4oPath
        {
            get
            {
                return this["fileDb4oPath"] as string;
            }
        }

        /// <summary>
        /// Gets the assembly with db4o database config.
        /// </summary>
        /// <value>The assembly with database config.</value>
        [ConfigurationProperty("assemblyWithDatabaseConfig")]
        public string AssemblyWithDatabaseConfig
        {
            get
            {
                return this["assemblyWithDatabaseConfig"] as string;
            }
        }

        /// <summary>
        /// Gets the static method with database config.
        /// </summary>
        /// <value>The static method with database config.</value>
        [ConfigurationProperty("staticMethodWithDatabaseConfig")]
        public string StaticMethodWithDatabaseConfig
        {
            get
            {
                return this["staticMethodWithDatabaseConfig"] as string;
            }
        }

        /// <summary>
        /// Gets the open server retries.
        /// </summary>
        /// <value>The open server retries.</value>
        [ConfigurationProperty("openServerRetriesOnLock")]
        public int OpenServerRetries
        {
            get
            {
                var retries = this["openServerRetriesOnLock"] as int?;
                return !retries.HasValue ? 0 : retries.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [open container on begin request].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [open container on begin request]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("openContainerOnBeginRequest")]
        public bool OpenContainerOnBeginRequest
        {
            get
            {
                var open = this["openContainerOnBeginRequest"] as bool?;
                return open.HasValue && open.Value ? true : false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [fill ID b4 O entity info].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [fill ID b4 O entity info]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("filldb4oentityinfo")]
        public bool FillIDB4OEntityInfo
        {
            get
            {
                var fill = this["filldb4oentityinfo"] as bool?;
                return fill.HasValue && fill.Value ? true : false;
            }
        }

        /// <summary>
        /// Gets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        [ConfigurationProperty("fillmode")]
        public DB4OFillOptions FillMode
        {
            get
            {
                var defaultFillOptions = DB4OFillOptions.FillGlobalID | DB4OFillOptions.FillLocalID | DB4OFillOptions.FillVersion;

                var fillOptions = this["fillmode"] as DB4OFillOptions?;

                if (!fillOptions.HasValue)
                    return defaultFillOptions;

                return fillOptions.Value;
            }
        }

        /// <summary>
        /// Exists any custom configuration.
        /// </summary>
        /// <returns></returns>
        public bool ExistAnyCustomConfiguration()
        {
            if (String.IsNullOrEmpty(StaticMethodWithDatabaseConfig))
                return false;

            return true;
        }

        /// <summary>
        /// Gets the server config.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetServerConfig<T>()
        {
            if(!ExistAnyCustomConfiguration())
                    throw new Exception("Not exist any configuration");

            var configParts         = StaticMethodWithDatabaseConfig.Split(new []{'.'});
            var configMethodClass   = String.Join(".", configParts, 0, configParts.Length -1);
            
            object config;
            
            try
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(asm => !asm.FullName.StartsWith("System.", StringComparison.Ordinal))
                    .ToList();

                Assembly configAssembly = null;

                if (!String.IsNullOrEmpty(AssemblyWithDatabaseConfig))
                {
                    var assemblyName = new AssemblyName(AssemblyWithDatabaseConfig);

                    configAssembly = assemblies
                        .FirstOrDefault(asm => asm.GetName().Name == assemblyName.Name);

                    if (configAssembly == null) //Maybe App_Code
                        configAssembly = Assembly.Load(AssemblyWithDatabaseConfig);
                }

                if (configAssembly == null)
                    configAssembly = assemblies
                        .FirstOrDefault(asm => asm.GetType(configMethodClass, false, true) != null);

                if (configAssembly == null)
                    throw new Exception(
                       String.Format("The type '{0}' of the config server´s property StaticMethodWithDatabaseConfig not exist in any loaded assembly"
                       , configMethodClass));

                var type = configAssembly
                    .GetType(configMethodClass, false, true);

                if (type == null)
                    throw new Exception(
                       String.Format("The type '{0}' of the config server´s property StaticMethodWithDatabaseConfig not exist in Assembly '{1}'"
                       , configMethodClass, configAssembly.FullName));
                
                var methodInfo = type.GetMethod(configParts[configParts.Length-1], 
                   BindingFlags.Static | BindingFlags.Public);

                config = methodInfo.Invoke(null, null);

                if (config == null)
                    throw new Exception(String.Format("The method '{0}' of type '{1}' returns null. If you don´t want apply custom configuration, delete the keys assemblyWithDatabaseConfig and staticMethodWithDatabaseConfig for database '{2}'", methodInfo.Name, type.Name, Alias));

            }
            catch(Exception excep)
            {
                Debug.Write(
                    String.Format("There is a problem calling the method '{0}' of the config server´s property GetConfigMethod: {1}",
                    StaticMethodWithDatabaseConfig,
                    excep.Message));

                throw;
            }

            return (T)config;
        }
        
    }
}