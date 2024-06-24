using Microsoft.AspNetCore.SignalR;

namespace Hubs;
public class NotificationsHub:Hub
{

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReciveMessage",$"{Context.ConnectionId} has joined");
    }

}