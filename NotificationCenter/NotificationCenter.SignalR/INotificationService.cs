using System.Threading.Tasks;

namespace NotificationCenter.SignalR
{
    public interface INotificationService
    {
        Task SendNotificationAsync(SignalRNotification message);
    }
}