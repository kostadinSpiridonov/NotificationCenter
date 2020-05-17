using NotificationCenter.Core.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.EventGenerator
{
    public interface INotificationGenerator
    {
        Task<IEnumerable<CertificateExpirationEvent>> GenerateAsync();
    }
}
