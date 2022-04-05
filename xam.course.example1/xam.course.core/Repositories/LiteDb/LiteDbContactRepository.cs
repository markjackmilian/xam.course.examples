using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using xam.course.core.Models;

namespace xam.course.core.Repositories.LiteDb
{
    public class LiteDbContactRepository  : IContactRepository
    {
        private readonly ILiteCollection<ContactModel> _collection;

        public LiteDbContactRepository(LiteDatabase database)
        {
            this._collection = database.GetCollection<ContactModel>();
        }
        
        public Task<ContactModel[]> GetContacts()
        {
            return Task.FromResult(this._collection.FindAll().ToArray());
        }

        public Task AddOrUpdateContact(ContactModel model)
        {
            return Task.FromResult(this._collection.Upsert(model));
        }

        public Task RemoveContact(ContactModel model)
        {
            this._collection.DeleteMany(contactModel => contactModel.Id == model.Id);
            return Task.CompletedTask;
        }
    }
}