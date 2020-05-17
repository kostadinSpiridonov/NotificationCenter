using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.SignalR
{
    internal class SignalRNotificationService : ISignalRNotificationService
    {
        private readonly IHubContext<NotificationHub> _hub;

        public SignalRNotificationService(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        public Task SendNotificationAsync(SignalRNotification message, IReadOnlyList<string> usernames)
        {
            return _hub.Clients.Users(usernames).SendAsync("ReceiveNotification", message.Content);
        }
    }
}