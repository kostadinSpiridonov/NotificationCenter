using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationsEventClientType
    {
        public int ClientTypeId { get; set; }
        public int NotificationEventId { get; set; }

        public virtual ClientType ClientType { get; set; }
        public virtual NotificationEvent NotificationEvent { get; set; }
    }
}
