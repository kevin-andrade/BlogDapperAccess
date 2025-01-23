using Azure.Core;
using Blog.Data;
using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.CategoryScreens
{
    public class ListCategoryWithPostsScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Category with Posts list");
            ScreenManager.AddMessage("-=-=-=-=-=-=-=-");

            Console.Write("Enter the ID of the Category: ");
            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid ID. Press any key to return.");
                Console.ReadKey();
                Menu.Load();
                return;
            }
            var category = new Repository<Category>(Database.Connection);
            category.Get(categoryId);

            try
            {
                DataBaseManager.ListCategoryWithPosts(Database.Connection, categoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error list: {ex.Message}");
            }

            Console.ReadKey();
            Menu.Load();
        }
    }
}
