using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } // Page title

        [Required]
        [MaxLength(5000)] // Allow a long description
        public string Description { get; set; } // Main content of the page

        [MaxLength(255)]
        public string ImagePath { get; set; } // MainImagePath 

        public List<string>? AdditionalImagePaths { get; set; } // Paths to additional images

    }
}
