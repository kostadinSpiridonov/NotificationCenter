using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class Client
    {
        public Client()
        {
            Certificates = new HashSet<Certificate>();
            Logins = new HashSet<Login>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
