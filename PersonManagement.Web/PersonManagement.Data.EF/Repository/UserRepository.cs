using Microsoft.EntityFrameworkCore;
using PersonManagement.Domain.POCO;
using PersonManagement.PersistanceDB.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Data.EF.Repository
{
    public class UserRepository : IUserRepository
    {

        private IBaseRepository<User> _repository;

        public UserRepository(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(User user)
        {
            await _repository.AddAsync(user);
            return user.Id;
        }

        public async Task<bool> Exists(string userName)
        {
            return await _repository.AnyAsync(x => x.UserName == userName);
        }

        public async Task<User> GetAsync(string username, string password)
        {
            return await _repository.Table.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
