using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xam.course.example1.Features.Contacts;

namespace xam.course.example1.Services
{
    public interface IContactService
    {
        event EventHandler<Contact> OnContactAdded;

        Task AddContact(Contact contact);
        Task<IEnumerable<Contact>> GetContacts();
    }

    class ContactService : IContactService
    {
        public event EventHandler<Contact> OnContactAdded;

        public Task AddContact(Contact contact)
        {
            // db stuff like
            this.OnContactAdded?.Invoke(this, contact);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            await Task.Delay(2000);
            
            var res = new List<Contact>()
            {
                new Contact
                {
                    Name = "Marco",
                    Surname = "milani",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Franco",
                    Surname = "Franchi",
                    Avatar =  $"https://i.pravatar.cc/150"

                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new Contact
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
            };

            return res;
        }
    }
}