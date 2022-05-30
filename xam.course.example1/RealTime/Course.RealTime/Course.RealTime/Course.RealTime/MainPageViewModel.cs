using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Course.RealTime.Models;
using Course.RealTime.Services;
using Plugin.LocalNotification;
using Xamarin.Forms;

namespace Course.RealTime
{
    public class MainPageViewModel : NotifyModel
    {
        private readonly ISignalrService _signalrService;

        public ObservableCollection<SignalRMessage> Messages { get; } = new ObservableCollection<SignalRMessage>();

        public ICommand SendMessage { get; set; }

        public MainPageViewModel(ISignalrService signalrService)
        {
            this._signalrService = signalrService;
            this._signalrService.OnConnected += (sender, args) => this.IsConnected = true;
            this._signalrService.OnDisconnected += (sender, args) => this.IsConnected = false;
            
            this._signalrService.OnMessageReceived += SignalrServiceOnOnMessageReceived;
            this._signalrService.OnChatUserConnected += async (sender, s) =>
            {
                var notification = new NotificationRequest
                {
                    NotificationId = 100,
                    Title = "New User",
                    Description = $"User connection: {s}",
                };
                await NotificationCenter.Current.Show(notification);
            };

            this.SendMessage = new Command(() => this._signalrService.SendMessage(this.NewMessage));
        }

        private void SignalrServiceOnOnMessageReceived(object sender, string message)
        {
            this.Messages.Add(new SignalRMessage
            {
                Text = message
            });
        }


        private bool _isConnected;

        public bool IsConnected
        {
            get => this._isConnected;
            set
            {
                if (value == this._isConnected) return;
                this._isConnected = value;
                this.OnPropertyChanged();
            }
        }

        private string _newMessage;
        public string NewMessage
        {
            get => this._newMessage;
            set
            {
                if (value == this._newMessage) return;
                this._newMessage = value;
                this.OnPropertyChanged();
            }
        }

        public async Task Connect()
        {
            await this._signalrService.Connect();
        }
    }
}