using PersonManagement.Services.Models;
using PersonManagement.Services.Models.@enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Services.Abstractions
{
    public interface IPersonService
    {
        Task<List<PersonServiceModel>> GetAllAsync();
        Task<PersonServiceModel> GetAsync(int id);
        Task<int> CreatAsync(PersonServiceModel person);
        Task<int> UpdateAsync(PersonServiceModel person);
        Task DeleteAsync(int id);
    }
}
