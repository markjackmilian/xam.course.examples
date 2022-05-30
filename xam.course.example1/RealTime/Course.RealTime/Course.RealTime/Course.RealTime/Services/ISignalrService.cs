using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Course.RealTime.Services
{
    public interface ISignalrService
    {
        Task Connect();

        event EventHandler OnConnected;
        event EventHandler<string> OnMessageReceived;
        event EventHandler<string> OnChatUserConnected;
        Task SendMessage(string newMessage);
        event EventHandler OnDisconnected;
    }

    class SignalrService : ISignalrService
    {
        private HubConnection _connection;

        public async Task Connect()
        {
            
            this._connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7031/chat", options =>
                {
                    options.HttpMessageHandlerFactory = handler => new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
                    };
                })
                .WithAutomaticReconnect()
                .Build();

            this._connection.Reconnecting += exception =>
            {
                this.OnDisconnected?.Invoke(this,EventArgs.Empty);
                return Task.CompletedTask;;
            };

            this._connection.Reconnected += s =>
            {
                this.OnConnected?.Invoke(this,EventArgs.Empty);
                return Task.CompletedTask;
            };
            
            this._connection.On<string>("clientMessageReceived", message =>
            {
                this.OnMessageReceived?.Invoke(this,message);
            });
            
            this._connection.On<string>("clientNewUserConnected", message =>
            {
                this.OnChatUserConnected?.Invoke(this,message);
            });
            
            await this._connection.StartAsync();
            this.OnConnected?.Invoke(this,EventArgs.Empty);
            
        }

        public event EventHandler OnConnected;
        public event EventHandler OnDisconnected;
        public event EventHandler<string> OnMessageReceived;
        public event EventHandler<string> OnChatUserConnected;

        public Task SendMessage(string newMessage)
        {
            return this._connection.SendAsync("SendMessage", newMessage);
        }
    }
}