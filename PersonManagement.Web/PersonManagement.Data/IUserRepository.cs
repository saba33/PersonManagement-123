using PersonManagement.Domain.POCO;
using System.Threading.Tasks;

namespace PersonManagement.Data
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string username, string password);
        Task<int> CreateAsync(User user);
        Task<bool> Exists(string userName);
    }
}
