﻿using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface INotificationEventRepository
    {
        Task<IEnumerable<NotificationEvent>> GetAllByTypeAsync(NotificationCrieriaType type, int clientTypeId);
    }
}