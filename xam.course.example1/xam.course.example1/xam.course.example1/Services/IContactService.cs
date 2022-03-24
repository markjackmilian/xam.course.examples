using System.Collections.Generic;
using System.Threading.Tasks;
using xam.course.example1.Features.Contacts;

namespace xam.course.example1.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
    }

    class ContactService : IContactService
    {
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            await Task.Delay(2000);
            
            var res = new List<Contact>()
            {
                new Contact
                {
                    Name = "Marco",
                    Surname = "milani",
                    Avatar =  "https://i.pravatar.cc"
                },
                new Contact
                {
                    Name = "Franco",
                    Surname = "Franchi",
                    Avatar =  "https://i.pravatar.cc"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  "https://i.pravatar.cc/"
                },
            };

            return res;
        }
    }
}