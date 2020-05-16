using NotificationCenter.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    public interface INotificationManager
    {
        Task Send(IEnumerable<NotificationModel> notifications);
    }
}
