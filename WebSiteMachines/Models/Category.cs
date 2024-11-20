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
        public virtual ICollection<Product>? Products { get; set; }
    }
}
