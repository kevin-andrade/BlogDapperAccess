using Blog.Data;

namespace Blog.UI.Screens.PostScreens
{
    public class ListPostsWithTagsScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Posts with Tag");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {

                DataBaseManager.ListPostsWithTags(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list: {ex.Message}");
            }
        }
    }
}
