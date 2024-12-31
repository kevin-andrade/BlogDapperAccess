using Blog.Models;
using System;
using static System.Net.Mime.MediaTypeNames;

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
    }
}