using Blog.Models;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration connection
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Path.Combine("Configurations", "appsettings.Development.json"), optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    Console.WriteLine("Connection string not found");
            //}
            //else
            //{
            //    Console.WriteLine("Connection String: " + connectionString);
            //}

            //METHOD
            ReadUsers();
            //ReadUser(connectionString);
            //CreateUser(connectionString);
            //UpdateUser(connectionString);
            //DeleteUser(connectionString);
        }

        public static void ReadUsers(SqlConnection connectionString)
        {
            var repository = new UserRepository(connectionString);
            var users = repository.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
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