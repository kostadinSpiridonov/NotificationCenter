using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationsCriteria
    {
        public NotificationsCriteria()
        {
            NotificationEvents = new HashSet<NotificationEvent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }

        public virtual ICollection<NotificationEvent> NotificationEvents { get; set; }
    }
}
