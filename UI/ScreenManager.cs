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

        public static UserRole GetRoleLinkUserData()
        {
            AddMessage($"Link Role to User");

            int userId = GetIdModel<User>("Role");
            int roleId = GetIdModel<Role>("User");

            return new UserRole() { UserId = userId, RoleId = roleId };
        }
    }
}