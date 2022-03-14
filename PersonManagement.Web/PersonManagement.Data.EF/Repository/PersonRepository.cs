using Microsoft.EntityFrameworkCore;
using PersonManagement.Domain.POCO;
using PersonManagement.PersistanceDB.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Data.EF.Repository
{
    public class PersonRepository : IPersonRepository
    {
        //HAS A

        private IBaseRepository<Person> _repository;

        public PersonRepository(IBaseRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Person> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<int> CreateAsync(Person person)
        {
            await _repository.AddAsync(person);
            return person.Id;
        }

        public async Task UpdateAsync(Person person)
        {
            await _repository.UpdateAsync(person);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.AnyAsync(x => x.Id == id);
        }
    }
}
