using Blog.UI.Screens.UserScreens;

namespace Blog.UI.Screens.TagScreens
{
    public class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("== Tag Manager ==");
            Console.WriteLine("1. Add Tag");
            Console.WriteLine("2. Update Tag");
            Console.WriteLine("3. Delete Tag");
            Console.WriteLine("4. List Tags With Post Count");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTagScreen.Load();
                    break;
                case "2":
                    UpdateTagScreen.Load();
                    break;
                case "3":
                    DeleteTagScreen.Load();
                    break;
                case "4":
                    ListTagsWithPostCountScreen.Load();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
