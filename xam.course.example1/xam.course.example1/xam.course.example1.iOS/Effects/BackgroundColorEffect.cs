using UIKit;
using xam.course.example1.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName("Xamarin")]
[assembly:ExportEffect(typeof(BackgroundColorEffect),"BackgroundColorEffect")]

namespace xam.course.example1.iOS.Effects
{
    public class BackgroundColorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var element = this.Element;
            var control = this.Control;

            if (control is UIButton uiButton)
            {
               uiButton.BackgroundColor = UIColor.Green;
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}