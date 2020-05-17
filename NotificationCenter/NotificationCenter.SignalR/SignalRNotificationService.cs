using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
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

        public async Task SendNotificationAsync(IEnumerable<SignalRNotification> messages)
        {
            foreach (var message in messages)
            {
                await _hub.Clients
                    .Users(message.Usernames.ToList())
                    .SendAsync("ReceiveNotification", message.Content);
            }
        }
    }
}