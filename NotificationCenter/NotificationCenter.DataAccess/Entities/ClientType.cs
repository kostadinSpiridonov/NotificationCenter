using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class ClientType
    {
        public ClientType()
        {
            Clients = new HashSet<Client>();
            NotificationsEventClientTypes = new HashSet<NotificationsEventClientType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<NotificationsEventClientType> NotificationsEventClientTypes { get; set; }
    }
}
