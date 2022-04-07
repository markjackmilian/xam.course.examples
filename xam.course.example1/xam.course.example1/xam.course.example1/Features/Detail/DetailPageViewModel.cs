using System.Windows.Input;
using xam.course.core.Models;
using xam.course.example1.Services;
using Xam.Zero.ViewModels;
using Xam.Zero.ZCommand;

namespace xam.course.example1.Features.Detail
{
    public class DetailPageViewModel : ZeroBaseModel
    {
        private readonly IContactService _contactService;
        public ICommand ProvaCommand { get; set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        
        public string Surname { get; set; }
        public string Name { get; set; }

        public DetailPageViewModel(IContactService contactService)
        {
            this._contactService = contactService;

            this.ProvaCommand = ZeroCommand.On(this)
                .WithExecute((o, context) => this.Name = "PIPPO")
                .Build();
            
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

        private void SaveContact()
        {
            var res = new ContactModel
            {
                Name = this.Name,
                Surname = this.Surname,
                Avatar = "https://i.pravatar.cc/150" 
            };
            this._contactService.AddContact(res);
            this.PopModal();
        }

      
    }

}