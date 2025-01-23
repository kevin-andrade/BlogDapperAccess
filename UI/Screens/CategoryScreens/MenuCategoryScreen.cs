using Blog.UI.Screens.RoleScreens;

namespace Blog.UI.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("== Category Manager ==");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Update Category");
            Console.WriteLine("3. Delete Category");
            Console.WriteLine("4. List Categories");
            Console.WriteLine("5. List Categories with Post count");
            Console.WriteLine("6. List Categories with Posts");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateCategoryScreen.Load();
                    break;
                case "2":
                    UpdateCategoryScreen.Load();
                    break;
                case "3":
                    DeleteCategoryScreen.Load();
                    break;
                case "4":
                    ListCategoriesScreen.Load();
                    break;
                case "5":
                    ListCategoryWithPostCountScreen.Load();
                    break;
                case "6":
                    ListCategoryWithPostsScreen.Load();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}

