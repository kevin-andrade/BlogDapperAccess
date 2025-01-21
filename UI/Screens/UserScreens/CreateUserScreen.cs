using Blog.Data;
using Blog.Models;

namespace Blog.UI.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Add a New User");
            var user = ScreenManager.GetData<User>();

            Create(user);

            Console.ReadKey();
            Menu.Load();

        }

        private static void Create(User user)
        {
            try
            {
                DataBaseManager.CreateEntity(Database.Connection, user);
                ScreenManager.AddMessage("User successfully registered!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
            }
        }
    }
}
