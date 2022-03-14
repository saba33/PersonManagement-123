using PersonManagement.Services.Models;
using PersonManagement.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Services.Abstractions
{
    public interface IUserService
    {
        Task<int> CreateAsync(UserServiceModel user);
        Task<string> AuthenticateAsync(string username, string password);
    }
}
