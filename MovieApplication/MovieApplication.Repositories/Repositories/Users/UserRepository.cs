using Microsoft.EntityFrameworkCore;
using MovieApplication.Core.Entities;
using MovieApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Repositories.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<User>> GetUsersByUsernameAsync(string username)
        {
            return await _databaseContext.Users.Where(u => u.Username.CompareTo(username) == 0).ToListAsync();
        }
    }
}
