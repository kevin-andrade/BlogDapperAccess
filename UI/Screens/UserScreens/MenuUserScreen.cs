namespace Blog.UI.Screens.UserScreens
{
    public class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("== User Manager ==");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. List Users");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateUserScreen.Load();
                    break;
                case "2":
                    UpdateUserScreen.Load();
                    break;
                case "3":
                    DeleteUserScreen.Load();
                    break;
                case "4":
                    ListUserScreen.Load();
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
