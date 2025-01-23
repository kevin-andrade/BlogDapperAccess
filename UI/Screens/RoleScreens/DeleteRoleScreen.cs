using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a Role");
            Console.WriteLine("-------------");
            Console.Write("Enter the ID of the Role to delete: ");

            if (!int.TryParse(Console.ReadLine(), out var roleId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                Console.ReadKey();
                return;
            }
            var repository = new Repository<Role>(Database.Connection);
            var role = repository.Get(roleId);

            Console.Write($"Are you sure you want to delete the role with ID {roleId}? (y/n): ");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
                repository.Delete(roleId);
            else
                Console.WriteLine("Operation canceled.");

            Console.ReadKey();
            Menu.Load();
        }
    }
}
