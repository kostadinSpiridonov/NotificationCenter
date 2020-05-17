using NotificationCenter.Core.Events;
using System;
using System.Collections.Generic;

namespace NotificationCenter.EventBroker
{
    public class EventBroker : IEventBroker
    {
        public event EventHandler<BaseEvent> EventHandler;

        public void EventOccured(BaseEvent e)
        {
            EventHandler?.Invoke(this, e);
        }

        public void EventsOccured(IEnumerable<BaseEvent> events)
        {
            foreach (var e in events)
            {
                EventOccured(e);
            }
        }
    }
}
