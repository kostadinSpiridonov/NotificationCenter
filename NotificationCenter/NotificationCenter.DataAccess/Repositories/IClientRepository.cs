using NotificationCenter.DataAccess.Entities;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetById(int clientId);
    }
}
