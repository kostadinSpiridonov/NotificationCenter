﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationCenter.Core.Events;
using NotificationCenter.DataAccess;

namespace NotificationCenter.EventGenerator
{
    internal class CertificateEventGenerator : IEventGenerator
    {
        private readonly IUnitOfWork _unitOfWork;

        public CertificateEventGenerator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CertificateExpirationEvent>> GenerateAsync()
        {
            var expiredCertifiicates = await _unitOfWork.CertificateRespoitory.GetExpiredCertificatesAsync();

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
