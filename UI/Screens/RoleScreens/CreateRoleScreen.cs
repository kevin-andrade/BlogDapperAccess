using Blog.Data;
using Blog.Models;

namespace Blog.UI.Screens.RoleScreens
{
    public class CreateRoleScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Add a New Role");
            var role = ScreenManager.GetData<Role>();

            Create(role);

            Console.ReadKey();
            Menu.Load();
        }

        private static void Create(Role role)
        {
            try
            {
                DataBaseManager.CreateEntity(Database.Connection, role);
                ScreenManager.AddMessage("Role successfully registered!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
            }
        }
    }
}
