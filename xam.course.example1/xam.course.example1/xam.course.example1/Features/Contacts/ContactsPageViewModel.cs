using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using xam.course.core.Models;
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
        public ICommand PickContactCommand { get; set; }
        
        private readonly IContactService _contactService;

        public ContactsPageViewModel(IContactService contactService)
        {
            this._contactService = contactService;
            this._contactService.OnContactAdded += (sender, contact) =>
            {
                this.Contacts.Add(contact);
            };

            this.PickContactCommand = ZeroCommand.On(this)
                .WithExecute(InnerPickContact)
                .Build();

            this.DeleteCommand = ZeroCommand<ContactModel>.On(this)
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

        private async void InnerPickContact(object arg1, ZeroCommandContext arg2)
        {
            try
            {
                var contact = await Xamarin.Essentials.Contacts.PickContactAsync();

                if(contact == null)
                    return;

                var mycontact = new ContactModel
                {
                    Name = contact.GivenName,
                    Surname = contact.FamilyName,
                    Avatar = "https://i.pravatar.cc/150",
                    FromContacts = true
                };

                await this._contactService.AddContact(mycontact);
                
            }
            catch (Exception ex)
            {
                var t = ex;
                // Handle exception here.
            }
        }

        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

        

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