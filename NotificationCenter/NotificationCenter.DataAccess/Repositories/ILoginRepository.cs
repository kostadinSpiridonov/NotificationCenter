using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> Exist(string username, string passwordHash);

        Task<IEnumerable<Login>> GetByClientId(int clientId, IEnumerable<string> clientTypes);
    }
}
