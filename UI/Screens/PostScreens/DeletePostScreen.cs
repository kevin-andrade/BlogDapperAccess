using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.PostScreens
{
    public class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a Post");
            Console.WriteLine("-------------");
            Console.Write("Enter the ID of the Post to delete: ");

            if (!int.TryParse(Console.ReadLine(), out var postId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                Console.ReadKey();
                return;
            }
            var repository = new Repository<Post>(Database.Connection);
            var post = repository.Get(postId);

            Console.Write($"Are you sure you want to delete the post with ID {postId}? (y/n): ");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
                repository.Delete(postId);
            else
                Console.WriteLine("Operation canceled.");

            Console.ReadKey();
            Menu.Load();
        }
    }
}
