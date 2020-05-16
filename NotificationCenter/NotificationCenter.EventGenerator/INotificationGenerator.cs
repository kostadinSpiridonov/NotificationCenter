using NotificationCenter.Core.Events;
using NotificationCenter.EventBroker;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.EventGenerator
{
    public interface INotificationGenerator
    {
        Task<IEnumerable<CertificateExpirationEvent>> Generate();
    }
}
