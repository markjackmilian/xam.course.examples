using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using xam.course.example1.Services;
using Xam.Zero.ViewModels;
using Xamarin.Forms.Internals;

namespace xam.course.example1.Features.Contacts
{
    public class ContactsPageViewModel : ZeroBaseModel
    {
        private readonly IContactService _contactService;

        public ContactsPageViewModel(IContactService contactService)
        {
            this._contactService = contactService;
        }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        protected override async void PrepareModel(object data)
        {
            var contacts = await this._contactService.GetContacts();
            this.Contacts.Clear();
            contacts.ForEach(contact => this.Contacts.Add(contact));
        }
    }
}