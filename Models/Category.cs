using Blog.Repositories.Interfaces;
using Dapper.Contrib.Extensions;
using System;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category : IRepository
    {
        public Category()
                => Posts = new List<Post>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}
