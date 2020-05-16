using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> Exist(string username, string passwordHash);
    }
}
