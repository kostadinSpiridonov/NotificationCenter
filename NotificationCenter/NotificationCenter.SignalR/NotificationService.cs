using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.SignalR
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationService(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        public Task SendNotificationAsync(SignalRNotification message, IReadOnlyList<string> usernames)
        {
            return _hub.Clients.Users(usernames).SendAsync("ReceiveMessage", message.Content);
        }
    }
}