using DryIoc;
using SQLite;
using xam.course.core.Repositories;
using xam.course.core.Repositories.Sqlite;

namespace xam.course.core
{
    public static class Startup
    {
        public static void Init(Container container)
        {
            container.UseInstance(new SQLiteAsyncConnection(Constants.SqliteDatabasePath, Constants.Flags));

            container.Register<IContactRepository, SqliteContactRepository>(Reuse.Singleton);
        }
    }
}