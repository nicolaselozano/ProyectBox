public interface INotificationStrategy
{
    Task SendNotification(string sender,string content,string sentTime,string userEmail=null);
}