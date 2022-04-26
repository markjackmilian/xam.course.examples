using System;
using DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace xam.course.example1.Features.Contacts
{
    public partial class ContactsPage : ContentPage
    {
        private readonly INativeViewFactory _nativeViewFactory;

        public Action<ContentView> AddNativeControl { get; set; }

        public ContactsPage(INativeViewFactory nativeViewFactory)
        {
            this._nativeViewFactory = nativeViewFactory;
            this.InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (this.nativeContent.Content == null)
            {
                // this.AddNativeControl?.Invoke(this.nativeContent);
                this.nativeContent.Content = this._nativeViewFactory.GetNativeView();
            }
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