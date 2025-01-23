using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a Category");
            Console.WriteLine("-------------");
            Console.Write("Enter the ID of the Category to delete: ");

            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                Console.ReadKey();
                return;
            }
            var repository = new Repository<Category>(Database.Connection);
            var category = repository.Get(categoryId);

            Console.Write($"Are you sure you want to delete the category with ID {categoryId}? (y/n): ");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
                repository.Delete(categoryId);
            else
                Console.WriteLine("Operation canceled.");

            Console.ReadKey();
            Menu.Load();
        }
    }
}
