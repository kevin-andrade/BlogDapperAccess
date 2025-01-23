using Blog.Data;

namespace Blog.UI.Screens.PostScreens
{
    public class ListPostsWithCategoryScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Posts with Category");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {

                DataBaseManager.ListPostsWithCategory(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list: {ex.Message}");
            }
        }
    }
}
