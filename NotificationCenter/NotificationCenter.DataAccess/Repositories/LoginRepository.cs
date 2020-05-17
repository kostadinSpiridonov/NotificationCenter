using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class LoginRepository : ILoginRepository
    {
        private readonly ExtendedNotificationCenterContext _context;

        public LoginRepository(ExtendedNotificationCenterContext context)
        {
            _context = context;
        }

        public Task<Login> GetAsync(string username, string passwordHash)
        {
            return _context.Logins.FirstOrDefaultAsync(x => 
                x.Username == username && 
                x.Password == passwordHash);
        }

        public async Task<IEnumerable<Login>> GetByClientIdAsync(int clientId, IEnumerable<string> clientTypes)
        {
            return await _context.Logins.Where(x => x.ClientId == clientId && clientTypes.Contains(x.Client.ClientType.Name)).ToListAsync();
        }
    }
}
