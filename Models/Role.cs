using Blog.Attributes;
using Blog.Repositories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Models
{
    [Table("[Role]")]
    public class Role : IRepository
    {
        [IgnoreProperty]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
