using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.TagScreens
{
    public class UpdateTagScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Update Tag");
            Console.Write("Enter the ID of the Tag to update: ");
            if (!int.TryParse(Console.ReadLine(), out var tagId))
            {
                Console.WriteLine("Invalid ID. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            var repository = new Repository<Tag>(Database.Connection);
            var existTag = repository.Get(tagId);
            if (existTag == null)
            {
                Console.WriteLine("Tag not found. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            Console.WriteLine("Existing tag data:");
            Console.WriteLine($"Name: {existTag.Id}");
            Console.WriteLine($"Email: {existTag.Name}");

            Console.WriteLine("\nEnter the new data for the Tag:");
            var updateTag = ScreenManager.GetData<Tag>();
            updateTag.Id = tagId;

            repository.Update(updateTag);

            Console.ReadKey();
            Menu.Load();
        }
    }
}
