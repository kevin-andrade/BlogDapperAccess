using Blog.Data;
using Blog.Models;

namespace Blog.UI.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Add a New Category");
            var category = ScreenManager.GetData<Category>();

            Create(category);

            Console.ReadKey();
            Menu.Load();
        }

        private static void Create(Category category)
        {
            try
            {
                DataBaseManager.CreateEntity(Database.Connection, category);
                ScreenManager.AddMessage("Category successfully registered!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
            }
        }
    }
}
