using Blog.Attributes;
using Blog.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag : IRepository
    {
        [IgnoreProperty]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        [IgnoreProperty]
        public int PostCount { get; set; }
    }
}