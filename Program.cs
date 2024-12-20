using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
// Criei a variavel connection dentro do metodo Main
namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONFIGURATION CONNECTION
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Path.Combine("Configurations", "appsettings.Development.json"), optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            //METHOD
            ReadUsers(connection);
            ReadRoles(connection);
            //ReadUser(connectionString);
            //CreateUser(connectionString);
            //UpdateUser(connectionString);
            //DeleteUser(connectionString);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.Get();

            foreach (var role in roles)
            {
                Console.WriteLine(role.Name);
            }
        }

        public static void ReadUser(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(2);
                Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser(string connectionString)
        {
            var user = new User()
            {
                Name = "Keven Andrade",
                Email = "keven@andrade.io",
                PasswordHash = "HASH",
                Bio = "Developer CSharp",
                Image = "https://",
                Slug = "keven-andrade"
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Insert(user);
                Console.WriteLine("User created successfully!");
            }
        }

        public static void UpdateUser(string connectionString)
        {
            var user = new User()
            {
                Id = 3,
                Name = "Keven Andrade",
                Email = "keven@andrade.io",
                PasswordHash = "HASH",
                Bio = "Developer CSharp | Python",
                Image = "https://",
                Slug = "keven-andrade"
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update(user);
                Console.WriteLine("Update carried out successfully!");
            }
        }

        public static void DeleteUser(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(2);
                connection.Delete(user);
                Console.WriteLine("Deletion carried out successfully!");
            }
        }
    }
}