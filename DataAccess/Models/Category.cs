﻿using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public string? CategoryImage { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
