﻿using Blog.Repositories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post : IRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
