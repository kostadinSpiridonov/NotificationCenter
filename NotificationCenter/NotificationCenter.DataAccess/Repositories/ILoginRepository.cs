﻿using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public interface ILoginRepository
    {
        Task<Login> GetAsync(string username, string passwordHash);
    }
}
