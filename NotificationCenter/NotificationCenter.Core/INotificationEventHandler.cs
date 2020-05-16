using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotificationCenter.Core
{
    public interface INotificationEventHandler
    {
        void Clear(IServiceProvider serviceProvider);
    }
}