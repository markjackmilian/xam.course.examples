using Android.Widget;
using xam.course.example1.Features.Contacts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

namespace xam.course.example1.Droid.Factories
{
    public class DroidNativeViewFactory : INativeViewFactory
    {
        public View GetNativeView()
        {
            var native = new ToggleButton(Application.Context);
            native.CheckedChange += (sender, args) =>
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Selezione", $"Il toggle è {native.Checked}", "ok");
            };

            return native.ToView();
        }
    }
}