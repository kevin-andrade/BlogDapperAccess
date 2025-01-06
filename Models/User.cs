using Blog.Attributes;
using Blog.Repositories.Interfaces;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Blog.Models
{
    [Table("[User]")]
    public class User : IRepository
    {
        public User()
            => Roles = new List<Role>();
        [IgnoreProperty]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [IgnoreProperty]
        [Write(false)]
        public List<Role> Roles { get; set; }
    }
}
