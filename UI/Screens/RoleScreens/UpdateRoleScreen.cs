using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.RoleScreens
{
    public class UpdateRoleScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Update Role");
            Console.Write("Enter the ID of the Role to update: ");
            if (!int.TryParse(Console.ReadLine(), out var roleId))
            {
                Console.WriteLine("Invalid ID. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            var repository = new Repository<Role>(Database.Connection);
            var existRole = repository.Get(roleId);
            if (existRole == null)
            {
                Console.WriteLine("Role not found. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            Console.WriteLine("Existing role data:");
            Console.WriteLine($"Name: {existRole.Name}");
            Console.WriteLine($"Slug: {existRole.Slug}");

            Console.WriteLine("\nEnter the new data for the role:");
            var updateRole = ScreenManager.GetData<Role>();
            updateRole.Id = roleId;

            repository.Update(updateRole);

            Console.ReadKey();
            Menu.Load();
        }
    }
}
