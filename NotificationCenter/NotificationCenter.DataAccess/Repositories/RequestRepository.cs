using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class RequestRepository : IRequestRepository
    {
        private readonly ExtendedNotificationCenterContext _context;

        public RequestRepository(ExtendedNotificationCenterContext context)
        {
            _context = context;
        }

        public Task Update(Request request)
        {
            return Task.FromResult(_context.Requests.Update(request));
        }

        public async Task<IEnumerable<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }
    }
}
