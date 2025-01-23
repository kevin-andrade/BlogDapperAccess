using Blog.Data;
using Blog.Models;

namespace Blog.UI.Screens.TagScreens
{
    public class CreateTagScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Add a New Tag");
            var tag = ScreenManager.GetData<Tag>();

            Create(tag);

            Console.ReadKey();
            Menu.Load();
        }

        private static void Create(Tag tag)
        {
            try
            {
                DataBaseManager.CreateEntity(Database.Connection, tag);
                ScreenManager.AddMessage("Tag successfully registered!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
            }
        }
    }
}
