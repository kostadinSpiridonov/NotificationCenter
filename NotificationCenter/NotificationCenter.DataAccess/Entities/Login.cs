using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class Login
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Client Client { get; set; }
    }
}
