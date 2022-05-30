using Microsoft.AspNetCore.SignalR;

namespace Course.SignalR;

public class ChatHub : Hub
{

    public Task SendMessage(string newMessage)
    {
        var senderId = this.Context.ConnectionId;
        return this.Clients.AllExcept(senderId).SendAsync("clientMessageReceived", newMessage);
    }

    public override Task OnConnectedAsync()
    {
        var senderId = this.Context.ConnectionId;
        return this.Clients.AllExcept(senderId).SendAsync("clientNewUserConnected", senderId);
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}