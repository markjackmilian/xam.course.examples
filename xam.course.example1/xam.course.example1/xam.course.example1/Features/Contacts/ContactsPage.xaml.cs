using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace xam.course.example1.Features.Contacts
{
    public partial class ContactsPage : ContentPage
    {
        
        public Action<ContentView> AddNativeControl { get; set; }

        public ContactsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if(this.nativeContent.Content == null)
                this.AddNativeControl?.Invoke(this.nativeContent);
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