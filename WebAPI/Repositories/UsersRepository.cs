using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetAll();
        User Get(int id);
        void Delete(int id);
        void Update(User updatedBank);
        void Insert(User bank);
    }

    public class UsersRepository : IUsersRepository
    {
        private string _connectionString;

        public UsersRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [UserId], [Name], [BankId], [Balance] FROM [Users]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int bankId = reader.GetInt32(2);
                            long balance = reader.GetInt64(3);

                            users.Add(new User
                            {
                                UserId = userId,
                                Name = name,
                                BankId = bankId,
                                Balance = balance
                            });
                        }
                    }
                }
            }

            return users;
        }

        public User Get(int id)
        {
            User user = new User();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "SELECT TOP 1 [UserId], [Name], [BankId], [Balance] FROM [Users] WHERE [UserId] = @UserId";
                    cmd.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int bankId = reader.GetInt32(2);
                            long balance = reader.GetInt64(3);

                            user = new User
                            {
                                UserId = userId,
                                Name = name,
                                BankId = bankId,
                                Balance = balance
                            };
                        }
                    }
                }
            }

            return user;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Users] WHERE [UserId] = @UserId";
                    cmd.Parameters.AddWithValue("@UserId", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Insert(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Users] ([Name], [BankId], [Balance]) VALUES(@Name, @BankId, @Balance)";
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@BankId", user.BankId);
                    cmd.Parameters.AddWithValue("@Balance", user.Balance);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(User updatedUser)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Users] SET [Name] = @Name, [BankId] =  @BankId, [Balance] = @Balance WHERE [UserId] = @UserId";
                    cmd.Parameters.AddWithValue("@UserId", updatedUser.UserId);
                    cmd.Parameters.AddWithValue("@Name", updatedUser.Name);
                    cmd.Parameters.AddWithValue("@BankId", updatedUser.BankId);
                    cmd.Parameters.AddWithValue("@Balance", updatedUser.Balance);

                    cmd.ExecuteNonQuery();
                }
            }
        }       

    }
}