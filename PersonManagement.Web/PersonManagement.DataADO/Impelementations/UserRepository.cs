using Microsoft.Extensions.Options;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.DataADO.Impelementations
{
    public class UserRepository : IUserRepository
    {
        const string SECRET_KEY = "rt3344wrrs354545";
        private readonly string _connection;

        public UserRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }


        public async Task<string> CreateAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string insertQuery = "INSERT INTO [User] OUTPUT INSERTED.UserName VALUES (@FirstName, @LastName, @UserName, @Password)";

                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("FirstName", user.FirstNam);
                command.Parameters.AddWithValue("LastName", user.LastName);
                command.Parameters.AddWithValue("UserName", user.UserName);

                var hashPassword = GenerateMD5Hash(user.Password + SECRET_KEY);
                command.Parameters.AddWithValue("Password", hashPassword);

                connection.Open();

                return (string)await command.ExecuteScalarAsync();
            }
        }

        public async Task<bool> Exists(string UserName)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string query = "SELECT COUNT(*) FROM [User] WHERE UserName = @UserName";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("UserName", UserName);

                connection.Open();

                int i =  (int)await command.ExecuteScalarAsync();

                return i > 0;   
            }
        }

        public async Task<User> GetAsync(string UserName, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string query = "SELECT * FROM [User] WHERE UserName = @UserName AND Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);

                var hashPassword = GenerateMD5Hash(password + SECRET_KEY);

                command.Parameters.AddWithValue("UserName", UserName);
                command.Parameters.AddWithValue("Password", hashPassword);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                User user = null;

                while (await reader.ReadAsync())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstNam = reader.GetString(1),
                        LastName = reader.GetString(2),
                        UserName = reader.GetString(3),
                        //Password = reader.GetString(4),
                    };
                }

                reader.Close();

                return user;

            }
        }

        private string GenerateMD5Hash(string input)
        {
            using(MD5 mD5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = mD5.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();   
            }
        }
    }
}
