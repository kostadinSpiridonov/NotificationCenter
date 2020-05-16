using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationCenter.Core.Events;
using NotificationCenter.DataAccess;
using NotificationCenter.EventBroker;

namespace NotificationCenter.EventGenerator
{
    public class CertificateNotificationGenerator : INotificationGenerator
    {
        private readonly IUnitOfWork _unitOfWork;

        public CertificateNotificationGenerator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CertificateExpirationEvent>> Generate()
        {
            var expiredCertifiicates = await _unitOfWork.CertificateRespoitory.GetExpiredCertificates();
            await _unitOfWork.Commit();

            return expiredCertifiicates.Select(x => new CertificateExpirationEvent()
            {
                SerialNumber = x.Id,
                EndDate = x.EndDate,
                StartDate = x.EndDate,
            });

        }
    }
}
