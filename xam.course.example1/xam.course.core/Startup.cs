using DryIoc;
using LiteDB;
using SQLite;
using xam.course.core.Repositories;
using xam.course.core.Repositories.LiteDb;
using xam.course.core.Repositories.Sqlite;

namespace xam.course.core
{
    public static class Startup
    {
        public static void Init(Container container)
        {
            // sqlite
            // container.UseInstance(new SQLiteAsyncConnection(Constants.SqliteDatabasePath, Constants.Flags));
            // container.Register<IContactRepository, SqliteContactRepository>(Reuse.Singleton);
            
            // litedb
            container.UseInstance(new LiteDatabase(new ConnectionString
            {
                Connection = ConnectionType.Direct,
                Filename = Constants.LiteDbDatabasePath
            }));
            container.Register<IContactRepository, LiteDbContactRepository>(Reuse.Singleton);

            
        }
    }
}