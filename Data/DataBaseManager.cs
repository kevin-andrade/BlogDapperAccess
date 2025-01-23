using Blog.Repositories.Interfaces;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Data
{
    public class DataBaseManager
    {
        public static void CreateEntity<TModel>(SqlConnection connection, TModel model) where TModel : class, IRepository
        {
            try
            {
                var repository = new Repository<TModel>(connection);
                repository.Create(model);
                Console.WriteLine($"{typeof(TModel).Name} created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating entity: {ex.Message}");
                throw;
            }
        }

        public static void UpdateEntity<TModel>(SqlConnection connection, TModel model) where TModel : class, IRepository
        {
            try
            {
                var repository = new Repository<TModel>(connection);
                repository.Update(model);

            }catch (Exception ex){
                Console.WriteLine($"Error updating {ex.Message}");
            }
        }

        public static void ListUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }

        public static void ListRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ListUsersWithRoles(SqlConnection connection)
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

        public static void ListCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var items = repository.Get();

            foreach (var item in items)
            { Console.WriteLine(item.Name); }
        }

        public static void ListCategoryWithPostsCount(SqlConnection connection)
        {
            var repository = new CategoryRepository(connection);
            var items = repository.GetCategoryWithPostCount();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} | {item.PostCount}");
            }
        }

        public static void ListCategoryWithPosts(SqlConnection connection, int categoryId)
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
        public static void ListTagsWithPostCount(SqlConnection connection)
        {
            var repository = new TagRepository(connection);
            var tags = repository.GetTagsWithPostCount();

            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Name} | Post Count: {tag.PostCount}");
            }
        }

        public static void ListPostsWithCategory(SqlConnection connection)
        {
            var repository = new PostRepository(connection);
            var posts = repository.GetPostsWithCategory();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post: {post.Title} | Category: {post.Category.Name}");
            }
        }

        public static void ListPostsWithTags(SqlConnection connection)
        {
            var repository = new PostRepository(connection);
            var tags = repository.GetPostsWithTags();

            foreach (var post in tags)
            {
                var formattedTags = FormatTags(post.Tags);
                Console.WriteLine($"Post: {post.Title} | Tags: {formattedTags}");
            }
        }
        private static string FormatTags(List<Tag> tags)
        {
            if (tags == null || tags.Count == 0)
                return "No tags";

            return string.Join(", ", tags.Select(tag => tag.Name));
        }
    }
}