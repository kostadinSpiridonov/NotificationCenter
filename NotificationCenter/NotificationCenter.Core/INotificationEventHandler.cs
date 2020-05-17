using System;

namespace NotificationCenter.Core
{
    public interface INotificationEventHandler
    {
        void Setup(IServiceProvider serviceProvider);
    }
}