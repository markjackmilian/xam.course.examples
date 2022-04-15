using System.Windows.Input;
using Xam.Zero.ViewModels;
using Xam.Zero.ZCommand;

namespace xam.course.example1.Features.ChooseSize
{
    public class ChooseSizeViewModel : ZeroPopupBaseModel<string>
    {
        public ICommand SelectedCommand { get; set; }

        public ChooseSizeViewModel()
        {
            this.SelectedCommand = ZeroCommand.On(this)
                // .WithCanExecute(() => this.Value != null)
                .WithExecute((o, context) => this.DismissPopup())
                .Build();
        }
    }
}