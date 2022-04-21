using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using DryIoc;
using Foundation;
using Lottie.Forms.Platforms.Ios;
using UIKit;
using xam.course.example1.Features.Contacts;
using xam.course.example1.Services;
using Xamarin.Forms;

namespace xam.course.example1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private Random _random;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            
            App.Container.Register<IDataReader,IosDatReader>(Reuse.Singleton);

            
            LoadApplication(new App());

            App.Close = () =>
            {
                // todo
            };
            
            var _ = new AnimationViewRenderer();
            

            // this.StartReadData();

            return base.FinishedLaunching(app, options);
        }

        private void StartReadData()
        {
            this._random = new Random();
            var timer = new Timer();
            timer.Elapsed += TimerOnElapsed;
            timer.Interval = 5000;
            timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            var nextValue = this._random.Next();

            MessagingCenter.Instance.Send(new object(),"dataRead",nextValue);
            
            // var vm = App.Container.Resolve<ContactsPageViewModel>();
            // vm.PlatformValue = nextValue;
        }
    }
}