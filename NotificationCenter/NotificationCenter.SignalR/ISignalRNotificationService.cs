using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.SignalR
{
    public interface ISignalRNotificationService
    {
        Task SendNotificationAsync(IEnumerable<SignalRNotification> messages);
    }
}