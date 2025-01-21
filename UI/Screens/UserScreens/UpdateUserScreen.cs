using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Update User");
            Console.Write("Enter the ID of the user to update: ");
            if (!int.TryParse(Console.ReadLine(), out var userId))
            {
                Console.WriteLine("Invalid ID. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            var repository = new Repository<User>(Database.Connection);
            var existingUser = repository.Get(userId);
            if (existingUser == null)
            {
                Console.WriteLine("User not found. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            Console.WriteLine("Existing user data:");
            Console.WriteLine($"Name: {existingUser.Name}");
            Console.WriteLine($"Email: {existingUser.Email}");

            Console.WriteLine("\nEnter the new data for the user:");
            var updatedUser = ScreenManager.GetData<User>();
            updatedUser.Id = userId;

            repository.Update(updatedUser);

            Console.ReadKey();
            Menu.Load();
        }
    }
}