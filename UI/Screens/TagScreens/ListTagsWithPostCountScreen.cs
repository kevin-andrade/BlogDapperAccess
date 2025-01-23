using Blog.Data;

namespace Blog.UI.Screens.TagScreens
{
    public class ListTagsWithPostCountScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Tag with Post Count list");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            List();

            Console.ReadKey();
            Menu.Load();
        }

        private static void List()
        {
            try
            {

                DataBaseManager.ListTagsWithPostCount(Database.Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list: {ex.Message}");
            }
        }
    }
}
