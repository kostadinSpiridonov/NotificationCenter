using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class NotificationEventRepository : INotificationEventRepository
    {
        private readonly ExtendedNotificationCenterContext _context;

        public NotificationEventRepository(ExtendedNotificationCenterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificationEvent>> GetAllByType(NotificationCrieriaType type)
        {
            return await _context.NotificationEvents
                .Include(x => x.NotificationEventChannels)
                    .ThenInclude(x => x.NotificationChannel)
                .Include(x => x.Criteria)
                .Include(x => x.NotificationsEventClientTypes)
                    .ThenInclude(x => x.ClientType)
                .Where(x => x.Criteria.Name == type.ToString())
                .ToListAsync();
        }
    }
}
