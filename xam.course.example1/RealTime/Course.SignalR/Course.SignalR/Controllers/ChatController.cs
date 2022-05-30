using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Course.SignalR.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly IHubContext<ChatHub> _chatHub;

    public ChatController(IHubContext<ChatHub> chatHub)
    {
        this._chatHub = chatHub;
    }

    [HttpPost("sendMessage")]
    public async Task<IActionResult> SendMessage(string message)
    {
        await this._chatHub.Clients.All.SendAsync("clientMessageReceived", message);
        return this.Ok();
    }
}