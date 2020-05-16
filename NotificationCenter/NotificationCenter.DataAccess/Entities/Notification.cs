using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Content { get; set; }

        public virtual Client Client { get; set; }
    }
}
