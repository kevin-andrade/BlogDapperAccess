using Blog.Data;
using Blog.Models;

namespace Blog.UI.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Add a New Post");
            var post = ScreenManager.GetData<Post>();

            Create(post);

            Console.ReadKey();
            Menu.Load();
        }

        private static void Create(Post post)
        {
            try
            {
                DataBaseManager.CreateEntity(Database.Connection, post);
                ScreenManager.AddMessage("Post successfully registered!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
            }
        }
    }
}
