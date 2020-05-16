using NotificationCenter.Core.Models;
using NotificationCenter.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Core.Managers
{
    public class WebManager : INotificationManager
    {
        private readonly INotificationService _notificationHub;

        public WebManager(INotificationService notificationHub)
        {
            _notificationHub = notificationHub;
        }

        public async Task Send(IEnumerable<NotificationModel> notifications)
        {
            foreach (var notification in notifications)
            {

                await _notificationHub.SendNotificationAsync(new SignalRNotification()
                {
                    Content = notification.Content
                }); ;
            }
        }
    }
}