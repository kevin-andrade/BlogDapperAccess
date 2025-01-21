using Blog.Repositories.Interfaces;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Data
{
    public class DataBaseManager
    {
        public static void CreateEntity<TModel>(SqlConnection connection, TModel model) where TModel : class, IRepository
        {
            try
            {
                var repository = new Repository<TModel>(connection);
                repository.Create(model);
                Console.WriteLine($"{typeof(TModel).Name} created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
                throw;
            }
        }

        public static void UpdateEntity<TModel>(SqlConnection connection, TModel model) where TModel : class, IRepository
        {
            try
            {
                var repository = new Repository<TModel>(connection);
                repository.Update(model);

            }catch (Exception ex){
                Console.WriteLine($"Error updating {ex.Message}");
            }
        }

        public static void ListUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }
    }
}