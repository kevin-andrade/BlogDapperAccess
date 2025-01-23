using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.PostScreens
{
    public class UpdatePostScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Update Post");
            Console.Write("Enter the ID of the Post to update: ");
            if (!int.TryParse(Console.ReadLine(), out var postId))
            {
                Console.WriteLine("Invalid ID. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            var repository = new Repository<Post>(Database.Connection);
            var existPost = repository.Get(postId);
            if (existPost == null)
            {
                Console.WriteLine("Post not found. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            Console.WriteLine("Existing post data:");
            Console.WriteLine($"Name: {existPost.Id}");
            Console.WriteLine($"Email: {existPost.Title}");

            Console.WriteLine("\nEnter the new data for the Post:");
            var updatePost = ScreenManager.GetData<Post>();
            updatePost.Id = postId;

            repository.Update(updatePost);

            Console.ReadKey();
            Menu.Load();
        }
    }
}
