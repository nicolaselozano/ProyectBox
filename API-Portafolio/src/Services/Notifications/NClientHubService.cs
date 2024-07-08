using Hubs;
using Microsoft.AspNetCore.SignalR;
using Reviews.Model;
using Reviews.Services;
using Users.Services;


namespace Notification.Services;
public class NClientHubService:INotificationStrategy
{
    private readonly IHubContext<NotificationsHub> _hubContext;
    private readonly ConnectionMapping _connectionMapping;
    public NClientHubService(IHubContext<NotificationsHub> hubContext, ConnectionMapping connectionMapping)
    {
        _hubContext = hubContext;
        _connectionMapping = connectionMapping;
    }

    public async Task SendNotification(string sender,string content,string sentTime,string userEmail)
    {
        Console.WriteLine($"conectando con Hub : {userEmail} : Emisor {sender}");
        Console.WriteLine(content);
        var connId = _connectionMapping.GetConnectionId(userEmail);
        Console.WriteLine($"conectionID {connId}");
        await _hubContext.Clients.Client(connId).SendAsync("ReceiveMessage", $"{content}");
        
        
    }

}