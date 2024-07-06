using Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Notification.Services;
public class NAllClientsHubService:INotificationStrategy
{
    private readonly IHubContext<NotificationsHub> _hubContext;
    public NAllClientsHubService(IHubContext<NotificationsHub> hubContext, ConnectionMapping connectionMapping)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotification(string sender,string content,string sentTime,string userEmail=null)
    {
        Console.WriteLine($"conectando con Hub, Emisor {sender}");

        await _hubContext.Clients.All.SendAsync("ReceiveMessage",$"{content}");
        
    }

}