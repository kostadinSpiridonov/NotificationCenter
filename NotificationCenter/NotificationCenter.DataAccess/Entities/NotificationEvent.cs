using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CriteriaId { get; set; }
        public int NotificationGroupId { get; set; }

        public virtual NotificationsCriteria Criteria { get; set; }
        public virtual NotificationsGroup NotificationGroup { get; set; }
    }
}
