using System;
using System.Configuration;

namespace UsefulDB4O.ApplicationConfig
{
    public class DB4ODatabaseValidator : ConfigurationValidatorBase
    {
        /// <summary>
        /// Determines whether an object can be validated based on type.
        /// </summary>
        /// <param name="type">The object type.</param>
        /// <returns>
        /// Es true si el valor del parámetro <paramref name="type"/> coincide con el tipo type esperado; en caso contrario, es false.
        /// </returns>
        public override bool CanValidate(Type type)
        {
            return type == typeof(DB4ODatabaseElementCollection);
        }

        /// <summary>
        /// Determina si el valor de un objeto es válido.
        /// </summary>
        /// <param name="value">Valor del objeto.</param>
        public override void Validate(object value)
        {
            var databases = value as DB4ODatabaseElementCollection;

            if(databases == null)
                return;

            foreach (DB4ODatabaseElement database in databases)
            {
                if (database.ExistAnyCustomConfiguration())
                {
                    var fullPathParts = database.StaticMethodWithDatabaseConfig.Split(new []{'.'});

                    if(fullPathParts.Length == 1)
                        throw new ConfigurationErrorsException(
                            "The property GetConfigMethodFullName must contain Namespace + Static Class Name + Get Config Method´s Name");
                }
                
                switch (database.ServerType)
                {
                    case Db4oServerType.NetworkingServer:

                        if (String.IsNullOrEmpty(database.RemoteHost))
                            throw new ConfigurationErrorsException(
                                "The property RemoteHost is required with Remote DatabaseType");

                        if (String.IsNullOrEmpty(database.RemoteUser))
                            throw new ConfigurationErrorsException(
                                "The property RemoteUser is required with Remote DatabaseType");

                        if (String.IsNullOrEmpty(database.RemotePassWord))
                            throw new ConfigurationErrorsException(
                                "The property RemotePassWord is required with Remote DatabaseType");

                        if (database.RemotePort <= 0)
                            throw new ConfigurationErrorsException(
                                "The property RemotePort is required with Remote DatabaseType");

                        break;
                    case Db4oServerType.EmbeddedServer:

                        if (String.IsNullOrEmpty(database.FileDb4oPath))
                            throw new ConfigurationErrorsException(
                                "The property FileDb4oPath is required with OneClient DatabaseType or MultipleClients DatabaseType");

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
