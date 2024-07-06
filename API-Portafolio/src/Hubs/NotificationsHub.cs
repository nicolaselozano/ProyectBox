using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using Notification.Services;

namespace Hubs;
public class NotificationsHub:Hub
{
    private readonly ConnectionMapping _connectionMapping;
    public NotificationsHub(ConnectionMapping connectionMapping)
    {
        _connectionMapping = connectionMapping;
    }

    public override async Task OnConnectedAsync()
    {
        var accessToken = Context.GetHttpContext().Request.Query["access_token"];
        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken = handler.ReadJwtToken(accessToken);

        string email = jwtToken.Claims.FirstOrDefault(c => c.Type == "custom_email_claim").Value.ToString();

        Console.WriteLine($"EMAIL : {email}");

        _connectionMapping.AddConnection(email, Context.ConnectionId);

        await Clients.All.SendAsync("ReceiveMessage", $"{email} se ha logueado");
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var accessToken = Context.GetHttpContext().Request.Query["access_token"];
        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken = handler.ReadJwtToken(accessToken);

        string email = jwtToken.Claims.FirstOrDefault(c => c.Type == "custom_email_claim").Value.ToString();

        _connectionMapping.RemoveConnection(email);

        await base.OnDisconnectedAsync(exception);
    }
}