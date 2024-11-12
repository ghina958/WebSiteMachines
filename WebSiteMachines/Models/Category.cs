﻿using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
