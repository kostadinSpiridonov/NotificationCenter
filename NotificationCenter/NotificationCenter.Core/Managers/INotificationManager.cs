using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    public interface INotificationManager
    {
        ChannelType ChannelType { get; }

        Task Send(IEnumerable<NotificationModel> notifications, IEnumerable<string> users);
    }
}
