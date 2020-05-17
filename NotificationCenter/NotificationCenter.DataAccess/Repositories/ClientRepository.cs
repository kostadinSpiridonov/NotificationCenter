using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly ExtendedNotificationCenterContext _context;

        public ClientRepository(ExtendedNotificationCenterContext context)
        {
            _context = context;
        }

        public Task<Client> GetById(int clientId)
        {
            return _context.Clients
                .Include(x => x.ClientType)
                .Include(x => x.Logins)
                .FirstOrDefaultAsync(x => x.Id == clientId);
        }
    }
}
