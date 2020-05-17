using NotificationCenter.Core.Events;
using System;
using System.Collections.Generic;

namespace NotificationCenter.EventBroker
{
    public interface IEventBroker
    {
        event EventHandler<BaseEvent> EventHandler;

        void EventOccured(BaseEvent e);

        void EventsOccured(IEnumerable<BaseEvent> events);
    }
}
