namespace Blog.UI.Screens.PostScreens
{
    public class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("== Post Manager ==");
            Console.WriteLine("1. Add Post");
            Console.WriteLine("2. Update Post");
            Console.WriteLine("3. Delete Post");
            Console.WriteLine("4. List Posts with Category");
            Console.WriteLine("5. List Posts with Tags");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreatePostScreen.Load();
                    break;
                case "2":
                    UpdatePostScreen.Load();
                    break;
                case "3":
                    DeletePostScreen.Load();
                    break;
                case "4":
                    ListPostsWithCategoryScreen.Load();
                    break;
                case "5":
                    ListPostsWithTagsScreen.Load(); break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
