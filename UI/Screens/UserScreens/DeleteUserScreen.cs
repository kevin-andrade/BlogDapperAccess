using Blog.Data;
using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a User");
            Console.WriteLine("-------------");
            Console.Write("Enter the ID of the user to delete: ");

            if (!int.TryParse(Console.ReadLine(), out var userId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                Console.ReadKey();
                return;
            }
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(userId);

            Console.Write($"Are you sure you want to delete the user with ID {userId}? (y/n): ");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
            {
                repository.Delete(userId);
            }
            else
            {
                Console.WriteLine("Operation canceled.");
            }

            Console.ReadKey();
            Menu.Load();
        }
    }

}
