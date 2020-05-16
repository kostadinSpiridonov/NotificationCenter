using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.SignalR
{
    public interface INotificationService
    {
        Task SendNotificationAsync(SignalRNotification message, IReadOnlyList<string> usernames);
    }
}