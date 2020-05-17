using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<Certificate>> GetExpiredCertificatesAsync();
    }
}