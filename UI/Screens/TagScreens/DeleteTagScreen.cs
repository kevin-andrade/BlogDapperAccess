using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.TagScreens
{
    public class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a Tag");
            Console.WriteLine("-------------");
            Console.Write("Enter the ID of the Tag to delete: ");

            if (!int.TryParse(Console.ReadLine(), out var tagId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                Console.ReadKey();
                return;
            }
            var repository = new Repository<Tag>(Database.Connection);
            var tag = repository.Get(tagId);

            Console.Write($"Are you sure you want to delete the tag with ID {tagId}? (y/n): ");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
                repository.Delete(tagId);
            else
                Console.WriteLine("Operation canceled.");

            Console.ReadKey();
            Menu.Load();
        }
    }
}
