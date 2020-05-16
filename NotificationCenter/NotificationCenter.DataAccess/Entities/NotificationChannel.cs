using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationChannel
    {
        public NotificationChannel()
        {
            NotificationEventChannels = new HashSet<NotificationEventChannel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NotificationEventChannel> NotificationEventChannels { get; set; }
    }
}
