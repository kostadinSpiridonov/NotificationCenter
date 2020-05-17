using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface IRequestRepository
    {
        Task UpdateAsync(Request request);

        Task<IEnumerable<Request>> GetAll();
    }
}
