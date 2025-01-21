using Blog.UI.Screens.UserScreens;

namespace Blog.UI.Screens
{
    public static class Menu
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("My Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1 - User management");
            Console.WriteLine("2 - Profile management");
            Console.WriteLine("3 - Category management");
            Console.WriteLine("4 - Tag managemennt");
            Console.WriteLine("5 - Link role/user");
            Console.WriteLine("6 - Link post/tag");
            Console.WriteLine("7 - Reports");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                case 4:
                    //MenuTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
