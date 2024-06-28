using Hubs;
using Microsoft.AspNet.SignalR;
using Reviews.Model;
using Reviews.Services;
using Users.Services;


namespace Notification.Services;
public class NLikedProyectService:INotificationStragy
{
    private readonly IHubContext<NotificationsHub> _hubContext;
    private readonly IReviewServices _reviewServices;
    private readonly ConnectionMapping _connectionMapping;
    public NLikedProyectService(IReviewServices reviewServices, IHubContext<NotificationsHub> hubContext, ConnectionMapping connectionMapping)
    {
        _reviewServices = reviewServices;
        _hubContext = hubContext;
        _connectionMapping = connectionMapping;
    }

    public async Task SendNotification(string sender,string content,string sentTime,string proyectId,string userEmail)
    {
        Review review = _reviewServices.GetReviewByEmail(Guid.Parse(proyectId),userEmail);
        foreach (var UserP in review.Proyect.UserProyects)
        {
            var connId = _connectionMapping.GetConnectionId(UserP.UserId.ToString());
            if (connId.Length != 0)
            {
                await _hubContext.Clients.Client(connId).SendAsync("ReceiveMessage", $"TU PROYECTO FUE LIKEADO POR {review.User.Email}");
            }
        }
    
    }

}