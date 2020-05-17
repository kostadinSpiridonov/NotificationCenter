using System.Collections.Generic;

namespace NotificationCenter.SignalR
{
    public class SignalRNotification
    {
        public string Content { get; set; }

        public IEnumerable<string> Usernames { get; set; }
    }
}
