using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationCenter.Core.Events;
using NotificationCenter.DataAccess;

namespace NotificationCenter.EventGenerator
{
    internal class CertificateNotificationGenerator : INotificationGenerator
    {
        private readonly IUnitOfWork _unitOfWork;

        public CertificateNotificationGenerator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CertificateExpirationEvent>> GenerateAsync()
        {
            var expiredCertifiicates = await _unitOfWork.CertificateRespoitory.GetExpiredCertificatesAsync();
            await _unitOfWork.CommitAsync();

            //TODO: use automapper
            return expiredCertifiicates.Select(x => new CertificateExpirationEvent
            {
                SerialNumber = x.Id,
                EndDate = x.EndDate,
                StartDate = x.EndDate,
                ClientId = x.ClientId
            });
        }
    }
}
