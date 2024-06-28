public interface INotificationStragy
{
    Task SendNotification(string sender,string content,string sentTime,string proyectId = null,string userEmail=null);
}