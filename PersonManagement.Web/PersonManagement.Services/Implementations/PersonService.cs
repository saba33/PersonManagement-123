using Mapster;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Exceptions;
using PersonManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Services.Implementations
{
    public class PersonService : IPersonService
    {
        #region Private Members

        private IPersonRepository _repo;

        #endregion

        #region Ctor
        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }


        

        #endregion

        #region Public Members
        public async Task<PersonServiceModel> GetAsync(int id)
        {
            var result = await _repo.GetAsync(id);

            if (result == null)
                throw new ObjectNotFoundException("პიროვნება ვერ მოიძებნა");

            return result.Adapt<PersonServiceModel>();
        }

        public async Task<List<PersonServiceModel>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            return result.Adapt<List<PersonServiceModel>>();
        }

        public async Task<int> CreatAsync(PersonServiceModel person)
        {
            var personToInsert = person.Adapt<Person>();

            var insertedId = await _repo.CreateAsync(personToInsert);

            return insertedId;
        }

        public async Task<int> UpdateAsync(PersonServiceModel person)
        {
            if (!await _repo.Exists(person.Id))
                throw new ObjectNotFoundException("პიროვნება ვერ მოიძებნა");

            var personToUpdate = person.Adapt<Person>();

            await _repo.UpdateAsync(personToUpdate);

            return person.Id;
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _repo.Exists(id))
                throw new ObjectNotFoundException("პიროვნება ვერ მოიძებნა");

            await _repo.DeleteAsync(id);
        }

        #endregion
    }
}
