﻿using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationEvent
    {
        public NotificationEvent()
        {
            NotificationEventChannels = new HashSet<NotificationEventChannel>();
            NotificationsEventClientTypes = new HashSet<NotificationsEventClientType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CriteriaId { get; set; }

        public virtual NotificationsCriteria Criteria { get; set; }
        public virtual ICollection<NotificationEventChannel> NotificationEventChannels { get; set; }
        public virtual ICollection<NotificationsEventClientType> NotificationsEventClientTypes { get; set; }
    }
}
