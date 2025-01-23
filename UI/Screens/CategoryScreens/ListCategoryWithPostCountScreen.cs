using Blog.Data;

namespace Blog.UI.Screens.CategoryScreens
{
    public class ListCategoryWithPostCountScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Category with Post Count list");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {
                DataBaseManager.ListCategoryWithPostsCount(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list: {ex.Message}");
            }
        }
    }
}
