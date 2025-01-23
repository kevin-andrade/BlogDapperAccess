using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Update Category");
            Console.Write("Enter the ID of the Category to update: ");
            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid ID. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            var repository = new Repository<Category>(Database.Connection);
            var existCategory = repository.Get(categoryId);
            if (existCategory == null)
            {
                Console.WriteLine("Category not found. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }

            Console.WriteLine("Existing category data:");
            Console.WriteLine($"Name: {existCategory.Name}");
            Console.WriteLine($"Slug: {existCategory.Slug}");

            Console.WriteLine("\nEnter the new data for the category:");
            var updateCategory = ScreenManager.GetData<Category>();
            updateCategory.Id = categoryId;

            repository.Update(updateCategory);

            Console.ReadKey();
            Menu.Load();
        }
    }
}
