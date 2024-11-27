using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Models;

namespace TaskApp.Services.Services.User
{
    public interface IUserService
    {
        Task<LoginResponse> Login(string email, string password);

        Task<CommonResponse> Register(UserRegisterModel registerModel);
    }
}
