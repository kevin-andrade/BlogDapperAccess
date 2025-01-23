using Blog.Models;
using Blog.Repositories;

namespace Blog.UI.Screens.LinksScreens
{
    public class PostToTagScreen
    {
        public static void Load()
        {
            ScreenManager.DrawScreen("Link Post to Tag");
            Save();
            Console.ReadKey();
            Menu.Load();
        }

        public static void Save()
        {
            var postTag = ScreenManager.GetPostLinkTagData();
            var postTagRepository = new JoinRepository<int, int, PostTag>(Database.Connection, "PostTag", "PostId", "TagId");
            postTagRepository.CreateRelation(postTag.PostId, postTag.TagId);

            //var relation = userRoleRepository.GetRelation(1, 2);
            //if (relation != null)
            //    Console.WriteLine($"UserId: {relation.UserId}, RoleId: {relation.RoleId}");
        }
    }
}
