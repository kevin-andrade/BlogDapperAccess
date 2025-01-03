using Blog.Models;
using Blog.Repositories;
using Blog.Repositories.Interfaces;
using Blog.UI;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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

            //ReadUsers(connection);
            //ReadRoles(connection);
            //ReadUsersWithRoles(connection);
            //ReadCategory(connection);
            //ReadTag(connection);
            //ReadItemId(connection);
            //CreateUser(connection);

            //UpdateUser(connectionString);
            //DeleteUser(connectionString);

            //ScreenManager.DrawScreen("Add a New User");
            //var user = ScreenManager.GetUserDate();
            //CreateEntity<User>(connection, user);
            //ScreenManager.AddMessage("User successfully registered!");

            //ScreenManager.DrawScreen("Add a New Role");
            //var role = ScreenManager.GetRoleDate();
            //CreateEntity<Role>(connection, role);
            //ScreenManager.AddMessage("Role successfully registered!");

            var userRole = ScreenManager.GetRoleLinkUserData();
            var userRoleRepository = new JoinRepository<int, int, UserRole>(connection, "UserRole", "UserId", "RoleId");
            userRoleRepository.CreateRelation(userRole.UserId, userRole.RoleId);

            //var relation = userRoleRepository.GetRelation(1, 2);
            //if (relation != null)
            //    Console.WriteLine($"UserId: {relation.UserId}, RoleId: {relation.RoleId}");

            ScreenManager.Pause();

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var items = repository.Get();

            foreach (var item in items)
            { Console.WriteLine(item.Name); }
        }

        public static void ReadTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
            { Console.WriteLine(item.Name); }
        }

        public static void ReadItemId(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var item = repository.Get(1);
            Console.WriteLine(item.Name);
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"- {role.Name}");
                }
            }
        }

        public static void CreateEntity<TModel>(SqlConnection connection, TModel model) where TModel : class, IRepository
        {
            var repository = new Repository<TModel>(connection);
            repository.Create(model);
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