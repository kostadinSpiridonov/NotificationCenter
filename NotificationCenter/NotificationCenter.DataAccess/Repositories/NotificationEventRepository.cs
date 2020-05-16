﻿using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public class NotificationEventRepository : INotificationEventRepository
    {
        private readonly NotificationCenterContext _context;

        public NotificationEventRepository(NotificationCenterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificationEvent>> GetAllByType(string type)
        {
            return await _context.NotificationEvents
                .Include(x => x.NotificationEventChannels)
                    .ThenInclude(x => x.NotificationChannel)
                .Include(x => x.Criteria)
                .Include(x => x.NotificationsEventClientTypes)
                    .ThenInclude(x => x.ClientType)
                .Where(x => x.Criteria.Name == type)
                .ToListAsync();
        }
    }
}
