using Microsoft.EntityFrameworkCore;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    internal class RequestRepository : IRequestRepository
    {
        private readonly NotificationCenterContext _context;

        public RequestRepository(NotificationCenterContext context)
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
