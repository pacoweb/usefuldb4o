using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace UsefulDB4O.ApplicationConfig
{
    [ConfigurationCollection(typeof(DB4ODatabaseElement), AddItemName = "database")]
    public class DB4ODatabaseElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets or sets the <see cref="UsefulDB4O.ApplicationConfig.DB4ODatabaseElement"/> at the specified index.
        /// </summary>
        /// <value></value>
        public DB4ODatabaseElement this[int index]
        {
            get
            {
                return BaseGet(index) as DB4ODatabaseElement;
            }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DB4ODatabaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DB4ODatabaseElement)element).Alias;
        }

        #region PUBLIC METHODS

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<DB4ODatabaseElement> GetAll()
        {
            return this.Cast<DB4ODatabaseElement>().ToList();
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns></returns>
        public DB4ODatabaseElement GetDatabase(string alias)
        {
            var database = BaseGet(alias) as DB4ODatabaseElement;
            return database;
        }

        #endregion

    }
}