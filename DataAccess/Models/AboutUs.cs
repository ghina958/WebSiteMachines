﻿using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } 

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } 

        [MaxLength(255)]
        public string ImagePath { get; set; }


    }
}
