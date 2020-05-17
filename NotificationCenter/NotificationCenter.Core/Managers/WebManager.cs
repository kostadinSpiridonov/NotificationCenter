﻿using NotificationCenter.Core.Models;
using NotificationCenter.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Core.Managers
{
    public class WebManager : INotificationManager
    {
        public string Type { get; set; } = "Web";
        private readonly ISignalRNotificationService _notificationHub;

        public WebManager(ISignalRNotificationService notificationHub)
        {
            _notificationHub = notificationHub;
        }

        public async Task Send(IEnumerable<NotificationModel> notifications, IEnumerable<string> users)
        {
            foreach (var notification in notifications)
            {

                await _notificationHub.SendNotificationAsync(new SignalRNotification()
                {
                    Content = notification.Content
                }, users.ToList());
            }
        }
    }
}