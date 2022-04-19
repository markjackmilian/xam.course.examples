using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace xam.course.example1.Features.Contacts
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            this.InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                var result = await this.DisplayAlert("Attenzione", "Vuoi davvero uscire?", "Si", "No");
                if (result)
                    App.Close();
            });

            return true;
        }
    }
}