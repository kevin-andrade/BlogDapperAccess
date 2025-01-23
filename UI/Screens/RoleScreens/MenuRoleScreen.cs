using Blog.UI.Screens.UserScreens;

namespace Blog.UI.Screens.RoleScreens
{
    public class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("== Role Manager ==");
            Console.WriteLine("1. Add Role");
            Console.WriteLine("2. Update Role");
            Console.WriteLine("3. Delete Role");
            Console.WriteLine("4. List Roles");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateRoleScreen.Load();
                    break;
                case "2":
                    UpdateRoleScreen.Load();
                    break;
                case "3":
                    DeleteRoleScreen.Load();
                    break;
                case "4":
                    ListRoleScreen.Load();
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
