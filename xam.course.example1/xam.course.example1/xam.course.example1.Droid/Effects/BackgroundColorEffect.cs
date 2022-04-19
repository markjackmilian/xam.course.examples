using xam.course.example1.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Android.Widget.Button;
using Color = Android.Graphics.Color;

[assembly:ResolutionGroupName("Xamarin")]
[assembly:ExportEffect(typeof(BackgroundColorEffect),"BackgroundColorEffect")]

namespace xam.course.example1.Droid.Effects
{
    public class BackgroundColorEffect  : PlatformEffect
    {
        protected override void OnAttached()
        {
            var button = (Button)this.Control;
            button.SetBackgroundColor(Color.Orange);
        }

        protected override void OnDetached()
        {
        }
    }
}