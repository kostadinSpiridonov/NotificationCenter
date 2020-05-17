using NotificationCenter.Core.Events;
using System;
using System.Collections.Generic;

namespace NotificationCenter.EventBroker
{
    public class EventBroker : IEventBroker
    {
        public event EventHandler<BaseEvent> EventHandler;

        public void OnEventOccured(BaseEvent e)
        {
            EventHandler?.Invoke(this, e);
        }

        public void OnEventsOccured(IEnumerable<BaseEvent> events)
        {
            foreach (var e in events)
            {
                OnEventOccured(e);
            }
        }
    }
}
