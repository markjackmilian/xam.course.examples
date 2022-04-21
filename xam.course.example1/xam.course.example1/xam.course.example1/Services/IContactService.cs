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

    public interface IDataReader
    {
        event EventHandler<int> DataReceived;
    }
    
    public interface IContactService
    {
        event EventHandler<ContactModel> OnContactAdded;

        Task AddContact(ContactModel contact);
        Task<IEnumerable<ContactModel>> GetContacts();

        Task Remove(ContactModel model);
        event EventHandler<ContactModel> OnContactRemoved;
    }

    class RepositoryContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public event EventHandler<ContactModel> OnContactAdded;
        public event EventHandler<ContactModel> OnContactRemoved;

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

        public async Task Remove(ContactModel model)
        {
            await this._contactRepository.RemoveContact(model);
            this.OnContactRemoved?.Invoke(this, model);
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

        public Task Remove(ContactModel model)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<ContactModel> OnContactRemoved;
    }
}