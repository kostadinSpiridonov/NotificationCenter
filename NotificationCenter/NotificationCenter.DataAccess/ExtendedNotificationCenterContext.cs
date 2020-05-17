using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NotificationCenter.DataAccess.ChangeProcessors;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.EventBroker;.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess
{
    internal class ExtendedNotificationCenterContext : NotificationCenterContext
    {
        private readonly IEventBroker _eventBroker;
        private readonly IDictionary<Type, IChangeProcessor> _changeProcessors;

        public ExtendedNotificationCenterContext(
            IEventBroker eventBroker,
            IDictionary<Type, IChangeProcessor> changeProcessors)
        {
            _eventBroker = eventBroker;
            _changeProcessors = changeProcessors;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> entires = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entry in entires)
            {
                if (_changeProcessors.TryGetValue(entry.Entity.GetType(), out IChangeProcessor processor))
                {
                    processor.Process(entry);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
