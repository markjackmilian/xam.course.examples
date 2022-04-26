using UIKit;
using xam.course.example1.Features.Contacts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace xam.course.example1.iOS.Factories
{
    public class IosNativeViewFactory : INativeViewFactory
    {
        public View GetNativeView()
        {
            var native = new UISegmentedControl("Uno", "Due");
            native.ValueChanged += (sender, args) =>
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Selezione", $"hai selezionato {native.SelectedSegment}", "ok");
            };

            return native.ToView();
        }
    }
}