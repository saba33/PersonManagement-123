using Microsoft.Extensions.Options;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PersonManagement.DataADO
{

    public class PersonRepository : IPersonRepository
    {
        #region Private Members

        private readonly string _connection;

        #endregion

        #region Ctor

        public PersonRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        #endregion

        #region Public Members
        public async Task<List<Person>> GetAllAsync()
        {
            List<Person> persons = new List<Person>();

            string selectQuery = "select  * from Persons";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    persons.Add(new Person
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Identifier = reader.GetString(3),
                        Gender = reader.GetBoolean(4),
                        BirthDate = reader.GetDateTime(5)
                    });
                }

                reader.Close();

                return persons;
            }
        }
        public async Task<Person> GetAsync(int id)
        {
            string selectQuery = "select  * from persons where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                Person person = null;

                while (await reader.ReadAsync())
                {
                    person = new Person
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Identifier = reader.GetString(3),
                        Gender = reader.GetBoolean(4),
                        BirthDate = reader.GetDateTime(5)
                    };
                }

                reader.Close();

                return person;
            }
        }

        //TODO: გავარჩოთ ადო ნეტის ყველა მეთოდი, შევადაროთ ExecuteReaderAsync ExecuteRreaderScalar -ს და ExecuteNonQueryAsync ა.შ
        public async Task<int> CreateAsync(Person person)
        {
            string selectQuery = "Insert into persons output INSERTED.Id  values(@FirstName,@LastName,@PersonIdentifier,@Gender,@BirthDate)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("FirstName", person.FirstName);
                command.Parameters.AddWithValue("LastName", person.LastName);
                command.Parameters.AddWithValue("PersonIdentifier", person.Identifier);
                command.Parameters.AddWithValue("Gender", person.Gender);
                command.Parameters.AddWithValue("BirthDate", person.BirthDate);

                connection.Open();

                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task UpdateAsync(Person person)
        {
            string selectQuery = "update  persons set FirstName=@FirstName,LastName=@LastName,PersonIdentifier=@PersonIdentifier,Gender=@Gender,BirthDate=@BirthDate where id = @id)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("id", person.Id);
                command.Parameters.AddWithValue("FirstName", person.FirstName);
                command.Parameters.AddWithValue("LastName", person.LastName);
                command.Parameters.AddWithValue("PersonIdentifier", person.Identifier);
                command.Parameters.AddWithValue("Gender", person.Gender);
                command.Parameters.AddWithValue("BirthDate", person.BirthDate);

                connection.Open();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            string selectQuery = "delete from persons where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            string selectQuery = "select Count(*) from persons where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                int count = (int)await command.ExecuteScalarAsync();

                return count > 0;
            }
        }

        #endregion
    }
}
