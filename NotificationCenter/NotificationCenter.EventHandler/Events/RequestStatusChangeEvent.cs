using NotificationCenter.EventBroker.Events;

namespace NotificationCenter.Core.Events
{
    public class RequestStatusChangeEvent : BaseEvent
    {
        public string RequestType { get; set; }

        public string RequestStatus { get; set; }

        public RequestStatusChangeEvent()
            : base(EventTypes.RequestStatusChange)
        {

        }

        public override string ToString()
        {
            return $"Status = {RequestStatus}, {RequestType}";
        }
    }
}
