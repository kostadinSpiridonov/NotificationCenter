using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationEventChannel
    {
        public int NotificationChannelId { get; set; }
        public int NotificationEventId { get; set; }

        public virtual NotificationChannel NotificationChannel { get; set; }
        public virtual NotificationEvent NotificationEvent { get; set; }
    }
}
