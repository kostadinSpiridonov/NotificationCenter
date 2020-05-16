using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.Core.Events;
using NotificationCenter.EventBroker;
using System;

namespace NotificationCenter.Core
{
    internal class NotificationEventHandler : INotificationEventHandler
    {
        private readonly IEventBroker _eventBroker;
        private IServiceProvider _serviceProvider;

        public NotificationEventHandler(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
        }

        private void Handle(object sender, BaseEvent e)
        {
            var eventProcessor = _serviceProvider.GetService<INotificationProcessor>();
            eventProcessor.Process(e);
        }

        public void Clear(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _eventBroker.EventHandler += Handle;
        }
    }
}
