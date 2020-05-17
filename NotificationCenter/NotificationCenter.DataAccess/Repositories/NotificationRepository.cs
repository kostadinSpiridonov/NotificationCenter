
using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class NotificationRepository : INotificationRepository
    {
        private readonly ExtendedNotificationCenterContext _context;

        public NotificationRepository(ExtendedNotificationCenterContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(IEnumerable<Notification> notifications)
        {
            await _context.Notifications.AddRangeAsync(notifications);
        }

        public async Task<IEnumerable<Notification>> GetByClientIdAsync(int clientId)
        {
            return await _context.Notifications.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}
