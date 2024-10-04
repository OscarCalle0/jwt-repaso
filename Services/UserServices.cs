using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepasoJWT.Data;
using RepasoJWT.Models;
using RepasoJWT.Repositories;

namespace RepasoJWT.Services
{
    public class UserServices : IUserRespository
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}