using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task SendNotificationAsync(SignalRNotification message)
        {
            return _hub.Clients.All.SendAsync("ReceiveMessage", message.Content);
        }
    }
}