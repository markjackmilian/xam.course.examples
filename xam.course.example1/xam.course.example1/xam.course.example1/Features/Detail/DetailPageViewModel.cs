using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using mjm.nethelpers.Extensions;
using xam.course.core.Models;
using xam.course.example1.Services;
using Xam.Zero.ViewModels;
using Xam.Zero.ZCommand;
using Xamarin.Essentials;

namespace xam.course.example1.Features.Detail
{
    public class DetailPageViewModel : ZeroPopupBaseModel
    {
        private readonly IContactService _contactService;
        public ICommand CloseCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand GetLocationCommand { get; private set; }

        public string Surname { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public Location Location { get; set; }

        public DetailPageViewModel(IContactService contactService)
        {
            this._contactService = contactService;
            
            this.GetLocationCommand = ZeroCommand.On(this)
                .WithCanExecute(() => this.Address.IsNullOrEmpty())
                .WithAutoInvalidateWhenExecuting()
                .WithExecute(async (o, context) =>
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    var location = await Geolocation.GetLocationAsync(request);

                    this.Location = location;
                })
                .Build();
            

            this.CloseCommand = ZeroCommand
                .On(this)
                // .WithExecute((o, context) => this.PopModal())
                .Build();

            this.SaveCommand = ZeroCommand
                .On(this)
                .WithExecute((o, context) => this.SaveContact())
                .WithCanExecute(() => !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Surname))
                .Build();
        }

        private async Task SaveContact()
        {
            if (this.Location == null)
            {
                var locations = this.Address.IsNullOrEmpty() ? null : await Geocoding.GetLocationsAsync(this.Address);
                this.Location = locations?.First();
            }
            else
            {
                var placeMark = await Geocoding.GetPlacemarksAsync(this.Location);
                this.Address = placeMark.First().Locality;
            }
            

            var res = new ContactModel
            {
                Name = this.Name,
                Surname = this.Surname,
                Avatar = "https://i.pravatar.cc/150",
                Address = this.Address,
                Location = this.Location
            };
            await this._contactService.AddContact(res);
            // await this.PopModal();
        }

        protected override void PrepareModel(object data)
        {
            this.Location = null;
            this.Name = null;
            this.Surname = null;
            this.Address = null;
        }
    }
}