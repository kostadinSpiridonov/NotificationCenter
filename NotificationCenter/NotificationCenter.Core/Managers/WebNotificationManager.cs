using NotificationCenter.Core.Models;
using NotificationCenter.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Core.Managers
{
    internal class WebNotificationManager : INotificationManager
    {
        public NotificationChannelTypeModel ChannelType { get; } = NotificationChannelTypeModel.Web;

        private readonly ISignalRNotificationService _notificationHub;

        public WebNotificationManager(ISignalRNotificationService notificationHub)
        {
            _notificationHub = notificationHub;
        }

        public async Task SendAsync(IEnumerable<NotificationModel> notifications)
        {
            // TODO: Use automapper
            var mappedNotifications = notifications.Select(x => new SignalRNotification
            {
                Content = x.Content,
                Usernames = x.Usernames
            });

            await _notificationHub.SendNotificationAsync(mappedNotifications);
        }
    }
}