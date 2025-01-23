using Blog.Data;

namespace Blog.UI.Screens.UserScreens
{
    public class UsersWithRolesScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Users with Roles");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {
                DataBaseManager.ListUsersWithRoles(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list users with roles: {ex.Message}");
            }
        }
    }
}
