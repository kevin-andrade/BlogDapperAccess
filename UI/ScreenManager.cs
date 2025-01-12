using Blog.Attributes;
using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.UI
{
    public static class ScreenManager
    {
        public static void DrawScreen(string title)
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine($"           {title}");
            Console.WriteLine("===================================");
            Console.WriteLine();
        }

        public static void AddMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static int GetIdModel<TModel>(string modelName) where TModel : class
        {
            while (true)
            {
                Console.Write($"Enter {modelName} ID: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int id) && id > 0)
                    return id;

                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }
        }

        public static T GetData<T>()
        {
            var type = typeof(T);
            var model = Activator.CreateInstance<T>();

            Console.WriteLine($"Enter data for {type.Name}:");

            foreach (var prop in type.GetProperties())
            {
                if (Attribute.IsDefined(prop, typeof(IgnorePropertyAttribute)))
                    continue;

                if (prop.CanWrite)
                {
                    Console.Write($"{prop.Name}: ");
                    var value = Console.ReadLine();

                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(model, value);
                    }
                    else if (prop.PropertyType == typeof(int))
                    {
                        if (int.TryParse(value, out var intValue))
                        {
                            prop.SetValue(model, intValue);
                        }
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        if (DateTime.TryParse(value, out var dateValue))
                        {
                            prop.SetValue(model, dateValue);
                        }
                    }
                }
            }

            return model;
        }


        public static User GetUserDate()
        {
            ScreenManager.AddMessage("Enter user data:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("PasswordHash: ");
            var passwordHash = Console.ReadLine();
            Console.Write("Bio: ");
            var bio = Console.ReadLine();
            Console.Write("Image: ");
            var image = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            return new User()
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug
            };
        }

        public static Role GetRoleDate()
        {
            ScreenManager.AddMessage("Enter role data:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            return new Role()
            {
                Name = name,
                Slug = slug
            };
        }

        public static Category GetCategoryData()
        {
            ScreenManager.AddMessage("Enter role data:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            return new Category()
            {
                Name = name,
                Slug = slug
            };
        }

        public static Tag GetTagData()
        {
            ScreenManager.AddMessage("Enter tag data:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            return new Tag()
            {
                Name = name,
                Slug = slug
            };
        }

        public static Post GetPostData()
        {
            AddMessage("Enter post data:");
            Console.Write("Author ID: ");
            var authorId = int.Parse(Console.ReadLine());
            Console.Write("Category ID: ");
            var categoryId = int.Parse(Console.ReadLine());
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Summary: ");
            var summary = Console.ReadLine();
            Console.Write("Body: ");
            var body = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var createDate = DateTime.Now;
            var lastUpdateDate = DateTime.Now;

            return new Post()
            {
                AuthorId = authorId,
                CategoryId = categoryId,
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = createDate,
                LastUpdateDate = lastUpdateDate
            };
        }

        public static UserRole GetRoleLinkUserData()
        {
            AddMessage($"Link Role to User");

            int userId = GetIdModel<User>("Role");
            int roleId = GetIdModel<Role>("User");

            return new UserRole() { UserId = userId, RoleId = roleId };
        }

        public static PostTag GetPostLinkTagData()
        {
            AddMessage($"Link Post to Tag");

            int postId = GetIdModel<Post>("Post");
            int tagId = GetIdModel<Tag>("Tag");

            return new PostTag() { PostId = postId, TagId = tagId };
        }
    }
}