using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface INotificationRepository
    {
        Task SaveAsync(IEnumerable<Notification> notifications);

        Task<IEnumerable<Notification>> GetByClientIdAsync(int clientId);
    }
}
