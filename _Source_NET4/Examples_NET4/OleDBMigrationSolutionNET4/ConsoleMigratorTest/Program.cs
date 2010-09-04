using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsefulDB4O.OleDBMigration;
using System.Reflection;

namespace ConsoleMigratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string db4OFilePath = @"C:\entities.db4o";
            
            using (var migrator = new OleDBDatabaseMigrator())
            {
                migrator.EntitiesAssembly       = Assembly.Load("Example.Entities");
                migrator.EntitiesNamespaceBase  = "Example.Entities";

                migrator.DataBaseConnectionString   = "Provider=SQLNCLI10;Server=localhost\\SQLEXPRESS2008;Database=AdventureWorks;Trusted_Connection=yes;";
                migrator.Db4oDataBaseFilePath       = db4OFilePath;

                migrator.LoadingTypeFromOleDb += (sender, e) =>
                {
                    
                    Console.WriteLine("Loading Type -->");

                    Console.WriteLine(String.Format("Type: {0}", e.EntityType));
                    Console.WriteLine(String.Format("Sql Query: {0}", e.SqlSelectQuery));

                    Console.WriteLine();
                };

                
                migrator.LoadedTypeFromOleDb += (sender, e) =>
                {
                    Console.WriteLine("Loaded Type -->");

                    Console.WriteLine(String.Format("Type {0} loaded. Rows count: {1}", e.EntityType, e.LoadedRowsCount));
                    
                    Console.WriteLine();
                };

                migrator.FillingTypeRelations += (sender, e) =>
                {
                    Console.WriteLine(String.Format("Filling type relations {0}", e.EntityType));
                    
                    Console.WriteLine();
                };

                migrator.FilledTypeRelations += (sender, e) =>
                {
                    Console.WriteLine(String.Format("Filled relations of type {0}", e.EntityType));
                    
                    Console.WriteLine();
                };

                Console.WriteLine("Process Starting...");
                migrator.Start();

            }

            Console.WriteLine("Process Ended");
            Console.WriteLine(String.Format("Your database file is in: {0}", db4OFilePath));
            Console.ReadLine();
        }
    }
}
