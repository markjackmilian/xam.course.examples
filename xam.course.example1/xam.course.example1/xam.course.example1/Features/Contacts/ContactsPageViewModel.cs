using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using xam.course.example1.Features.Detail;
using xam.course.example1.Services;
using Xam.Zero.ViewModels;
using Xam.Zero.ZCommand;
using Xamarin.Forms.Internals;

namespace xam.course.example1.Features.Contacts
{
    public class ContactsPageViewModel : ZeroBaseModel
    {
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        
        private readonly IContactService _contactService;

        public ContactsPageViewModel(IContactService contactService)
        {
            this._contactService = contactService;
            this._contactService.OnContactAdded += (sender, contact) =>
            {
                this.Contacts.Add(contact);
            };

            this.DeleteCommand = ZeroCommand<Contact>.On(this)
                .WithExecute((contact, context) =>
                {
                    this.Contacts.Remove(contact);
                })
                .Build();

            this.CreateCommand = ZeroCommand
                .On(this)
                .WithExecute((o, context) => this.PushModal<DetailPage>())
                .Build();
        }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        protected override async void PrepareModel(object data)
        {
            var contacts = await this._contactService.GetContacts();
            this.Contacts.Clear();
            contacts.ForEach(contact => this.Contacts.Add(contact));
        }

        // protected override void ReversePrepareModel(object data)
        // {
        //     this.Contacts.Add((Contact)data);
        // }
    }
}