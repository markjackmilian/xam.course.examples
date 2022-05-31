using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DryIoc;
using xam.course.example1.Droid.Factories;
using xam.course.example1.Features.Contacts;
using xam.course.example1.Services;
using Xamarin.Forms.Platform.Android;

namespace xam.course.example1.Droid
{
    [Activity(Label = "xam.course.example1", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Rg.Plugins.Popup.Popup.Init(this);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            Xamarin.FormsMaps.Init(this,savedInstanceState);

            
            App.Container.Register<IDataReader,DroidDataReader>(Reuse.Singleton);
            App.Container.Register<INativeViewFactory,DroidNativeViewFactory>();

            
            LoadApplication(new App());
            //this.AddNativeView();
            
            App.Close = this.FinishAffinity;
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }

        private void AddNativeView()
        {
            var page = App.Container.Resolve<ContactsPage>();
            page.AddNativeControl = view =>
            {
                var native = new ToggleButton(Application.Context);
                native.CheckedChange += (sender, args) =>
                {
                    page.DisplayAlert("Selezione", $"Il toggle è {native.Checked}", "ok");
                };

                view.Content = native.ToView();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            // if (requestCode == RequestLocationId)
            // {
            //     if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
            //         // Permissions granted - display a message.
            //         else
            //     // Permissions denied - display a message.
            // }
            // else
            // {
            //     base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            // }
            
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}