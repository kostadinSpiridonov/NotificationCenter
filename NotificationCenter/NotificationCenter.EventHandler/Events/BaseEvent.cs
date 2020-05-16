namespace NotificationCenter.Core.Events
{
    public abstract class BaseEvent
    {
        public string Type { get; private set; }
        public int ClientId { get;  set; }

        public BaseEvent(string type)
        {
            Type = type;
        }
    }
}
