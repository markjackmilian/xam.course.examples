using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xam.course.core.Models;
using xam.course.core.Repositories;
using xam.course.example1.Features.Contacts;
using Xamarin.Essentials;

namespace xam.course.example1.Services
{
    public interface IContactService
    {
        event EventHandler<ContactModel> OnContactAdded;

        Task AddContact(ContactModel contact);
        Task<IEnumerable<ContactModel>> GetContacts();
    }

    class RepositoryContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public event EventHandler<ContactModel> OnContactAdded;

        public RepositoryContactService(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        public async Task AddContact(ContactModel contact)
        {
            await this._contactRepository.AddOrUpdateContact(contact);
            this.OnContactAdded?.Invoke(this, contact);
        }

        public async Task<IEnumerable<ContactModel>> GetContacts()
        {
            var res = await this._contactRepository.GetContacts();
            return res.AsEnumerable();
        }
    }

    class ContactService : IContactService
    {
        public event EventHandler<ContactModel> OnContactAdded;

        public Task AddContact(ContactModel contact)
        {
            // db stuff like
            this.OnContactAdded?.Invoke(this, contact);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ContactModel>> GetContacts()
        {
            await Task.Delay(2000);
            
            var res = new List<ContactModel>()
            {
                new ContactModel
                {
                    Name = "Marco",
                    Surname = "milani",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Franco",
                    Surname = "Franchi",
                    Avatar =  $"https://i.pravatar.cc/150"

                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
                {
                    Name = "Ciccio",
                    Surname = "Ingrassia",
                    Avatar =  $"https://i.pravatar.cc/150"
                },
                new ContactModel
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