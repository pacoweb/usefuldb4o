using System.Configuration;

namespace UsefulDB4O.ApplicationConfig
{
    public class DB4OConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Name of the section in config file
        /// </summary>
        public const string DB4OSectionName = "db4o";

        //Singleton
        private static DB4OConfigSection _instance;

        /// <summary>
        /// Returns the configuration for db4o
        /// </summary>
        /// <returns>Db4oConfigSection instance</returns>
        public static DB4OConfigSection GetInstance()
        {
            return _instance ?? (_instance = ConfigurationManager.GetSection(DB4OSectionName) as DB4OConfigSection);
        }

        /// <summary>
        /// Gets the databases.
        /// </summary>
        /// <value>The databases.</value>
        [ConfigurationProperty("databases", IsDefaultCollection=true)]
        [ConfigurationValidator(typeof(DB4ODatabaseValidator))]
        public DB4ODatabaseElementCollection Databases
        {
            get
            {
                return this["databases"] as DB4ODatabaseElementCollection;
            }
        }
    }
}