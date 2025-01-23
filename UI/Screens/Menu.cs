using Blog.UI.Screens.CategoryScreens;
using Blog.UI.Screens.LinksScreens;
using Blog.UI.Screens.PostScreens;
using Blog.UI.Screens.RoleScreens;
using Blog.UI.Screens.TagScreens;
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
            Console.WriteLine("5 - Post managemennt");
            Console.WriteLine("6 - Link role/user");
            Console.WriteLine("7 - Link post/tag");
            Console.WriteLine("8 - Reports");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5: MenuPostScreen.Load(); break;
                case 6: RoleToUserScreen.Load(); break;
                case 7: PostToTagScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}
