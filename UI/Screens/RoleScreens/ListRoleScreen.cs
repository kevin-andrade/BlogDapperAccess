using Blog.Data;

namespace Blog.UI.Screens.RoleScreens
{
    public class ListRoleScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Role list");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {
                DataBaseManager.ListRoles(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list roles: {ex.Message}");
            }
        }
    }
}
