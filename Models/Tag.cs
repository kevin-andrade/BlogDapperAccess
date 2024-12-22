using Blog.Repositories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag : IRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}