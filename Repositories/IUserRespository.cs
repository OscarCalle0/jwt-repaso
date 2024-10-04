using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepasoJWT.Models;

namespace RepasoJWT.Repositories
{
    public interface IUserRespository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string email);
    }
}