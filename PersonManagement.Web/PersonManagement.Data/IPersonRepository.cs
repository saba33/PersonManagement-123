using PersonManagement.Domain.POCO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Data
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetAsync(int id);
        Task<int> CreateAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
