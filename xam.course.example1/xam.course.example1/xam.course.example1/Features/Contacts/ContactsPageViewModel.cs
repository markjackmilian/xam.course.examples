using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using mjm.nethelpers.Extensions;
using Serilog;
using xam.course.core.Models;
using xam.course.example1.Features.ChooseSize;
using xam.course.example1.Features.Detail;
using xam.course.example1.Services;
using Xam.Zero.ViewModels;
using Xam.Zero.ZCommand;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace xam.course.example1.Features.Contacts
{
    public class ContactsPageViewModel : ZeroBaseModel
    {
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand PickContactCommand { get; set; }
        public ICommand ChooseSizeCommand { get; set; }

        public bool IsBusy { get; set; }
        public int PlatformValue { get; set; }

        private readonly IContactService _contactService;
        private readonly IDataReader _dataReader;
        private readonly ILogger _logger;

        public ContactsPageViewModel(IContactService contactService, IDataReader dataReader, ILogger logger)
        {
            this._contactService = contactService;
            this._dataReader = dataReader;
            this._logger = logger;
            this._contactService.OnContactAdded += (sender, contact) => { this.Contacts.Add(contact); };
            this._contactService.OnContactRemoved += (sender, contact) => { this.Contacts.Remove(contact); };


            dataReader.DataReceived += (sender, i) =>
            {
                this.PlatformValue = i;
            };
            
            
            // MessagingCenter.Instance.Subscribe<object,int>(this,"dataRead", (o,i) =>
            // {
            //     this.PlatformValue = i;
            // });
            
            // App.OnDataReceived += (sender, i) =>
            // {
            //     this.PlatformValue = i;
            // };

            this.ChooseSizeCommand = ZeroCommand.On(this)
                .WithExecute(async (o, context) =>
                {
                    var res = await this.ShowPopup<ChooseSizePage, string>();
                    await this.DisplayAlert("Hai scelto:", res, "ok");
                    Analytics.TrackEvent("Size",new Dictionary<string, string>
                    {
                        {"size",res}
                    });
                    Analytics.TrackEvent("Prova");
                })
                .Build();
            
            this.PickContactCommand = ZeroCommand.On(this)
                .WithExecute(InnerPickContact)
                .Build();

            this.DeleteCommand = ZeroCommand<ContactModel>.On(this)
                .WithExecute(async (contact, context) =>
                {
                    var res = await this.DisplayAlert("Attenzione", "Vuoi eleminare il contatto?", "Si", "No");

                    if (!res) return;
                    
                    await this._contactService.Remove(contact);
                })
                .Build();

            this.CreateCommand = ZeroCommand
                .On(this)
                .WithExecute((o, context) => this.ShowPopup<DetailPage>())
                .Build();
        }

        private async void InnerPickContact(object arg1, ZeroCommandContext arg2)
        {
            try
            {
                var contact = await Xamarin.Essentials.Contacts.PickContactAsync();

                if (contact == null)
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
            this._logger.Information("ContactPage opened");
            try
            {
                this.IsBusy = true;
                await Task.Delay(3000);
                var contacts = await this._contactService.GetContacts();
                this.Contacts.Clear();
                contacts.ForEach(contact => this.Contacts.Add(contact));
            }
            finally
            {
                this.IsBusy = false;
            }
            
        }

        // protected override void ReversePrepareModel(object data)
        // {
        //     this.Contacts.Add((Contact)data);
        // }
    }
}