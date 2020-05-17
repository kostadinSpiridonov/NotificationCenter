using NotificationCenter.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    public interface INotificationManager
    {
        NotificationChannelTypeModel ChannelType { get; }

        Task SendAsync(IEnumerable<NotificationModel> notifications);
    }
}
