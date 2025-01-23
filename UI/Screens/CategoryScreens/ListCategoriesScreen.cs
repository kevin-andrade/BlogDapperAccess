using Blog.Data;

namespace Blog.UI.Screens.CategoryScreens
{
    public class ListCategoriesScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Category list");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {
                DataBaseManager.ListCategories(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list categories: {ex.Message}");
            }
        }
    }
}
