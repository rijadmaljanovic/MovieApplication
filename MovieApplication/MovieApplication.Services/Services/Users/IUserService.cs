using MovieApplication.Core.Entities;
using MovieApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Services.Services.Users
{
    public interface IUserService
    {
        Task<string> LoginAndGenerateJWTAsync(LoginModel model);

    }
}
