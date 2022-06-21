using MovieApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Repositories.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersByUsernameAsync(string username);

    }
}
