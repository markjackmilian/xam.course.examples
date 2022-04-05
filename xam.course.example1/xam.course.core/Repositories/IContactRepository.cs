using System.Threading.Tasks;
using xam.course.core.Models;

namespace xam.course.core.Repositories
{
    public interface IContactRepository
    {
        Task<ContactModel[]> GetContacts();
        Task AddOrUpdateContact(ContactModel model);
    }
}