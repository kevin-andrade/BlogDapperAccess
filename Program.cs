using Blog.Models;
using Blog.Repositories;
using Blog.UI;
using Blog.UI.Screens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONFIGURATION CONNECTION
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Path.Combine("Configurations", "appsettings.Development.json"), optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();

            Menu.Load();

            ScreenManager.Pause();

            Database.Connection.Close();

            //ReadRoles(connection);
            //ReadUsersWithRoles(connection);
            //ReadCategory(connection);
            //ReadCategoryWithPostsCount(connection);
            //ReadTagsWithPostCount(connection);
            //ReadPostsWithCategory(connection);
            //ReadPostsWithTags(connection);
            //var categoryId = ScreenManager.GetIdModel<Category>("Category");
            //ReadCategoryWithPosts(connection, categoryId);
            //ReadTag(connection);
            //ReadItemId(connection);
            //CreateUser(connection);

            //DeleteUser(connectionString);

            //ScreenManager.DrawScreen("Add a New Role");
            //var role = ScreenManager.GetData<Role>();
            //CreateEntity<Role>(connection, role);
            //ScreenManager.AddMessage("Role successfully registered!");

            //ScreenManager.DrawScreen("Add a New Category");
            //var category = ScreenManager.GetData<Category>();
            //CreateEntity<Category>(connection, category);
            //ScreenManager.AddMessage("Category successfully registered!");

            //ScreenManager.DrawScreen("Add a New Tag");
            //var tag = ScreenManager.GetData<Tag>();
            //CreateEntity<Tag>(connection, tag);
            //ScreenManager.AddMessage("Tag successfully registered!");

            //ScreenManager.DrawScreen("Add a New Post");
            //var post = ScreenManager.GetData<Post>();
            //CreateEntity<Post>(connection, post);
            //ScreenManager.AddMessage("Post successfully registered!");

            //var userRole = ScreenManager.GetRoleLinkUserData();
            //var userRoleRepository = new JoinRepository<int, int, UserRole>(connection, "UserRole", "UserId", "RoleId");
            //userRoleRepository.CreateRelation(userRole.UserId, userRole.RoleId);

            //var relation = userRoleRepository.GetRelation(1, 2);
            //if (relation != null)
            //    Console.WriteLine($"UserId: {relation.UserId}, RoleId: {relation.RoleId}");

            //var postTag = ScreenManager.GetPostLinkTagData();
            //var postTagRepository = new JoinRepository<int, int, PostTag>(connection, "PostTag", "PostId", "TagId");
            //postTagRepository.CreateRelation(postTag.PostId, postTag.TagId);

        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                string roles = item.Roles.Any()
                    ? $"Roles: {string.Join(", ", item.Roles.Select(role => role.Name))}"
                    : "Roles: No role assigned";

                Console.WriteLine($"{item.Name} | {item.Email} | {roles}");
            }
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadCategoryWithPostsCount(SqlConnection connection)
        {
            var repository = new CategoryRepository(connection);
            var items = repository.GetCategoryWithPostCount();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} | {item.PostCount}");
            }
        }

        public static void ReadCategoryWithPosts(SqlConnection connection, int categoryId)
        {
            var repository = new CategoryRepository(connection);
            var items = repository.GetCategoryWithPosts(categoryId);

            if (items == null)
            {
                Console.WriteLine($"Category with ID {categoryId} not found.");
                return;
            }

            Console.WriteLine($"Category: {items.Name}");

            if (!items.Posts.Any())
            {
                Console.WriteLine("No posts found for this category.");
                return;
            }

            Console.WriteLine("Posts:");
            foreach (var item in items.Posts)
            {
                Console.WriteLine($"- Title: {item.Title}");
                Console.WriteLine($"  Summary: {item.Summary}");
                Console.WriteLine($"  Slug: {item.Slug}");
                Console.WriteLine($"  Created On: {item.CreateDate}");
                Console.WriteLine($"  Last Updated: {item.LastUpdateDate}");
                Console.WriteLine();

            }
        }

        public static void ReadTagsWithPostCount(SqlConnection connection)
        {
            var repository = new TagRepository(connection);
            var tags = repository.GetTagsWithPostCount();

            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Name} | Post Count: {tag.PostCount}");
            }
        }

        public static void ReadPostsWithCategory(SqlConnection connection)
        {
            var repository = new PostRepository(connection);
            var posts = repository.GetPostsWithCategory();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post: {post.Title} | Category: {post.Category.Name}");
            }
        }

        public static void ReadPostsWithTags(SqlConnection connection)
        {
            var repository = new PostRepository(connection);
            var tags = repository.GetPostsWithTags();

            foreach (var post in tags)
            {
                var formattedTags = FormatTags(post.Tags);
                Console.WriteLine($"Post: {post.Title} | Tags: {formattedTags}");
            }
        }

        public static string FormatTags(List<Tag> tags)
        {
            if (tags == null || tags.Count == 0)
                return "No tags";

            return string.Join(", ", tags.Select(tag => tag.Name));
        }

        public static void ReadCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var items = repository.Get();

            foreach (var item in items)
            { Console.WriteLine(item.Name); }
        }

        public static void ReadTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
            { Console.WriteLine(item.Name); }
        }

        public static void ReadItemId(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var item = repository.Get(1);
            Console.WriteLine(item.Name);
        }

    }
}