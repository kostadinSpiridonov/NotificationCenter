
using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class NotificationRepository : INotificationRepository
    {
        private readonly NotificationCenterContext _context;

        public NotificationRepository(NotificationCenterContext context)
        {
            _context = context;
        }

        public async Task Save(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public async Task<IEnumerable<Notification>> GetByClientId(int clientId)
        {
            return await _context.Notifications.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}
