using Microsoft.AspNetCore.SignalR;

namespace Hubs;
public class NotificationsHub:Hub
{

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveMessage",$"{Context.ConnectionId} has joined");
    }

}