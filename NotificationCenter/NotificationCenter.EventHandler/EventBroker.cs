using NotificationCenter.Core.Events;
using System;

namespace NotificationCenter.EventBroker
{
    public class EventBroker : IEventBroker
    {
        public event EventHandler<BaseEvent> EventHandler;

        public void OnEventOccured(BaseEvent e)
        {
            EventHandler?.Invoke(this, e);
        }
    }
}
