using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } // The title of the service (e.g., "Hydraulic jacks")

        public virtual ICollection<SubService>? SubServices { get; set; } // Navigation property to Category

        public bool IsActive { get; set; } = true;
    }
}
