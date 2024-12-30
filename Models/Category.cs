using Blog.Repositories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<Post> Posts { get; set; }
    }
}
