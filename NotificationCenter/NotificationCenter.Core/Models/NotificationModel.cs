using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;

namespace NotificationCenter.Core.Models
{
    public class NotificationModel
    {
        public string Content { get; set; }

        public int ClientId { get; set; }

        public IEnumerable<string> Usernames { get; set; }
        
        public IEnumerable<NotificationChannelTypeModel> Channels { get; set; }
    }
}
