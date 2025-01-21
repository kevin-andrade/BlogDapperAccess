using Blog.Data;

namespace Blog.UI.Screens.UserScreens
{
    public class ListUserScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("User list");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {
                DataBaseManager.ListUsers(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list users: {ex.Message}");
            }
        }
    }
}
