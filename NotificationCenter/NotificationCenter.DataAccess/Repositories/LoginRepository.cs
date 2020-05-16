using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly NotificationCenterContext _context;

        public LoginRepository(NotificationCenterContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(string username, string passwordHash)
        {
            return await _context.Logins.AnyAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task<IEnumerable<Login>> GetByClientId(int clientId, IEnumerable<string> clientTypes)
        {
            return await _context.Logins.Where(x => x.ClientId == clientId && clientTypes.Contains(x.Client.ClientType.Name)).ToListAsync();
        }
    }
}
