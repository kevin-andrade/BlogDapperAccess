using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.LinksScreens
{
    public class RoleToUserScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Link Role to User");
            Save();
            Console.ReadKey();
            Menu.Load();
        }

        public static void Save()
        {
            var userRole = ScreenManager.GetRoleLinkUserData();
            var userRoleRepository = new JoinRepository<int, int, UserRole>(Database.Connection, "UserRole", "UserId", "RoleId");
            userRoleRepository.CreateRelation(userRole.UserId, userRole.RoleId);
        }
    }
 }
