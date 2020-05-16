using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class Request
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

        public virtual Client Client { get; set; }
    }
}
