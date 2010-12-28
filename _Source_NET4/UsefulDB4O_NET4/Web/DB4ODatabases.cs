using System;
using System.Diagnostics;
using System.Web;
using Db4objects.Db4o;


namespace UsefulDB4O.Web
{
    public static class DB4ODatabases
    {

        /// <summary>
        /// Gets the current context container for a database
        /// </summary>
        /// <param name="databaseAlias">The database alias.</param>
        /// <returns></returns>
        public static IObjectContainer GetCurrentContextContainer(string databaseAlias)
        {
            if (String.IsNullOrEmpty(databaseAlias))
                throw new ArgumentNullException(databaseAlias);

            var context = HttpContext.Current;

            if(context == null)
                throw new ApplicationException("The HttpContext.Current is null. You must use this method on a ASP.NET Web site");

            var db4oModule = context.ApplicationInstance.Modules.Get(DB4OHttpModule.Db4OHttpModuleTypeName) as DB4OHttpModule;

            if (db4oModule == null)
                throw new ApplicationException(String.Format("You have to add the DB4OHttpModule in your web.config using the name '{0}'"
                    , DB4OHttpModule.Db4OHttpModuleTypeName));

            var container = db4oModule.GetContainer(databaseAlias, context);

            if (container == null)
                throw new ApplicationException(String.Format("The database alias '{0}' not exists in the databases collection of web.config"
                    , databaseAlias));

            Debug.WriteLine(String.Format("GetCurrentContextContainer '{0}' ", databaseAlias));

            return container;
        }
    }
}
