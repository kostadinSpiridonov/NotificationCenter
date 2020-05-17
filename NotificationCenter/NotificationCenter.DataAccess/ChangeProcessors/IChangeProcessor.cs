using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NotificationCenter.DataAccess.ChangeProcessors
{
    internal interface IChangeProcessor
    {
        void Process(EntityEntry entityEntry);
    }
}
