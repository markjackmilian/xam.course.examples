using System.Threading.Tasks;
using SQLite;
using xam.course.core.Models;

namespace xam.course.core.Repositories.Sqlite
{
    class SqliteContactRepository : IContactRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public SqliteContactRepository(SQLiteAsyncConnection database)
        {
            this._database = database;
            this._database.CreateTableAsync<ContactModel>().Wait();
        }

        public Task<ContactModel[]> GetContacts()
        {
            return this._database.Table<ContactModel>().ToArrayAsync();
        }

        public Task AddOrUpdateContact(ContactModel model)
        {
            return model.Id == 0 ? this._database.InsertAsync(model) : this._database.UpdateAsync(model);
        }

        public Task RemoveContact(ContactModel model)
        {
            return this._database.DeleteAsync(model);
        }
    }
}