using Mapster;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models.User;
using System.Threading.Tasks;

namespace PersonManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IJWTService _jwtService;
        private readonly IUserRepository _repo;

        public UserService(IJWTService jwtService, IUserRepository repo)
        {
            _repo = repo;
            _jwtService = jwtService;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var userEntity = await _repo.GetAsync(username, password);

            if (userEntity == null)
                throw new System.Exception();

            return _jwtService.GenerateSecurityToken(userEntity.UserName);
        }

        public async Task<int> CreateAsync(UserServiceModel user)
        {
            return await _repo.CreateAsync(user.Adapt<User>());
        }
    }
}
