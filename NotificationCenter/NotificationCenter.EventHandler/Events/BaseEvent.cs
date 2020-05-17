using NotificationCenter.EventBroker.Events;

namespace NotificationCenter.Core.Events
{
    public abstract class BaseEvent
    {
        public EventTypes Type { get; private set; }
        public int ClientId { get;  set; }

        public BaseEvent(EventTypes type)
        {
            Type = type;
        }
    }
}
