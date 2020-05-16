using NotificationCenter.Core.Events;
using System;

namespace NotificationCenter.EventBroker
{
    public interface IEventBroker
    {
        event EventHandler<BaseEvent> EventHandler;

        void OnEventOccured(BaseEvent e);
    }
}
