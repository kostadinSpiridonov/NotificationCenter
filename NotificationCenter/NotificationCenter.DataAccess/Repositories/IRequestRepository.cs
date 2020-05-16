using NotificationCenter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface IRequestRepository
    {
        Task Update(Request request);

        Task<IEnumerable<Request>> GetAll();
    }
}
