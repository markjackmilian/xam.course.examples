using System;
using System.IO;
using System.Threading.Tasks;
using DryIoc;
using LiveSharp.Runtime;
using nightly.serilog.xamarin;
using Serilog;
using xam.course.core;
using xam.course.example1.Features.Contacts;
using xam.course.example1.Services;
using Xam.Zero;
using Xam.Zero.DryIoc;
using Xam.Zero.RGPopup;
using Xam.Zero.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ILogger = Serilog.ILogger;

[assembly: ExportFont("icomoon.ttf", Alias = "icomoon")]
[assembly: ExportFont("Samantha.ttf", Alias = "customFont")]
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace xam.course.example1
{
    public partial class App : Application
    {
        
        public static Action Close { get; set; }

        public static object Sender = new object();
            

        public static event EventHandler<int> OnDataReceived;
        
        public static readonly Container Container = new Container(rules =>
        {
            rules = rules.WithDefaultIfAlreadyRegistered(IfAlreadyRegistered.Keep);
            return rules.WithoutFastExpressionCompiler();
        });
        
        public App()
        {
            InitializeComponent();
            
            Startup.Init(Container);
            this.InitLogger();
            Container.Register<IContactService,RepositoryContactService>(Reuse.Singleton);

            var errorManager = new ErrorManager(ErrorAction);
            Container.UseInstance(errorManager);
            
            ZeroApp.On(this)
                .WithPopupNavigator(RGPopupNavigator.Build())
                .WithContainer(DryIocZeroContainer.Build(Container))
                .StartWithPage<ContactsPage>();
        }

        private void InitLogger()
        {
            var seqAddress = "http://localhost:5341";
            var logDirectory = Path.Combine(FileSystem.CacheDirectory, "logs");
            Directory.CreateDirectory(logDirectory);

            var filePath = Path.Combine(logDirectory, "logfile.log");

            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Async(configuration => configuration.Seq(seqAddress))
                .WriteTo.Async(configuration =>
                    configuration.File(filePath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7))
                .Enrich.WithSessionId()
                .Enrich.WithDeviceInfos()
                .Enrich.WithDisplayInfos()
                .Enrich.WithAppVersionInfos()
                .Enrich.WithDeviceId()
                .Enrich.WithDevelopment(true)
                .Enrich.WithUserName(() => "marco");

            loggerConfig.WriteTo.DebugConsole();


            var logger = loggerConfig.CreateLogger();
            Container.RegisterDelegate<ILogger>(context => logger);
        }

        private Task ErrorAction(Exception ex)
        {
            // Crashes.TrackError(ex);
            Container.Resolve<ILogger>().Error(ex, ex.Message);

            return MainThread.InvokeOnMainThreadAsync(() =>
            {
                this.MainPage.DisplayAlert("Attenzione", "Si è verificato un errore", "ok");
            }); 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}