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
    public class DetailPageViewModel : ZeroBaseModel
    {
        private readonly IContactService _contactService;
        public ICommand CloseCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public string Surname { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public DetailPageViewModel(IContactService contactService)
        {
            this._contactService = contactService;

            this.CloseCommand = ZeroCommand
                .On(this)
                .WithExecute((o, context) => this.PopModal())
                .Build();

            this.SaveCommand = ZeroCommand
                .On(this)
                .WithExecute((o, context) => this.SaveContact())
                .WithCanExecute(() => !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Surname))
                .Build();
        }

        private async Task SaveContact()
        {
            var locations = this.Address.IsNullOrEmpty() ? null : await Geocoding.GetLocationsAsync(this.Address);
            var location = locations?.First();

            var res = new ContactModel
            {
                Name = this.Name,
                Surname = this.Surname,
                Avatar = "https://i.pravatar.cc/150",
                Address = this.Address,
                Location = location
            };
            await this._contactService.AddContact(res);
            await this.PopModal();
        }
    }
}