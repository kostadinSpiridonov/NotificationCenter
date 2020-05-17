using System;

namespace NotificationCenter.DataAccess.Entities
{
    public partial class NotificationChannel
    {
        public ChannelType Type
        {
            get
            {
                return Enum.Parse<ChannelType>(Name);
            }
        }
    }
}
