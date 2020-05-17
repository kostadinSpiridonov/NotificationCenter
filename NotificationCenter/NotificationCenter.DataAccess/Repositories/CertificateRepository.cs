using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class CertificateRepository : ICertificateRepository
    {
        private readonly ExtendedNotificationCenterContext _context;

        public CertificateRepository(ExtendedNotificationCenterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certificate>> GetExpiredCertificatesAsync()
        {
            var today = DateTime.Now.Date;

            return await _context.Certificates
                .Where(x => x.EndDate.Date == today)
                .ToListAsync();
        }
    }
}
