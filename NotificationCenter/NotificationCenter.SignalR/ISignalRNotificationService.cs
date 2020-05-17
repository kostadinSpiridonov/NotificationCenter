using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.SignalR
{
    public interface ISignalRNotificationService
    {
        Task SendNotificationAsync(SignalRNotification message, IReadOnlyList<string> usernames);
    }
}