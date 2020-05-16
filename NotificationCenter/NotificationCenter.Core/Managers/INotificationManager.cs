using NotificationCenter.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    public interface INotificationManager
    {
        public string Type { get; set; }

        Task Send(IEnumerable<NotificationModel> notifications);
    }
}
