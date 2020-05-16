using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface INotificationRepository
    {
        Task Save(Notification notification);

        Task<IEnumerable<Notification>> GetAll();
    }
}
