using Microsoft.EntityFrameworkCore.ChangeTracking;
using NotificationCenter.Core.Events;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.EventBroker;

namespace NotificationCenter.DataAccess.ChangeProcessors
{
    internal class RequestChangeProcessor : IChangeProcessor
    {
        private readonly IEventBroker _eventBroker;

        public RequestChangeProcessor(IEventBroker notificationEventBroker)
        {
            _eventBroker = notificationEventBroker;
        }

        public void Process(EntityEntry entityEntry)
        {
            var entity = entityEntry.Entity as Request;
            if (entityEntry.CurrentValues[nameof(Request.Status)] != entityEntry.OriginalValues[nameof(Request.Status)])
            {
                _eventBroker.EventOccured(new RequestStatusChangeEvent
                {
                    ClientId = entity.ClientId,
                    RequestStatus = entity.Status,
                    RequestType = entity.Type
                });
            }
        }
    }
}
