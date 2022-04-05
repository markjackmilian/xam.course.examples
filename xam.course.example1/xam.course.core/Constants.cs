using System;
using System.IO;

namespace xam.course.core
{
    
    static class Constants
    {
        const string SqliteDatabaseFilename = "ExampleSQLite.db3";
        const string LiteDbDatabaseFilename = "ExampleLiteDb.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string SqliteDatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, SqliteDatabaseFilename);
            }
        }
        
        public static string LiteDbDatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, LiteDbDatabaseFilename);
            }
        }
    }
}