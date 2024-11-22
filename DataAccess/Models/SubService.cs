using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteMachines.Models
{
    public class SubService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; } 
        public virtual Service? Services { get; set; }
        public string? SubServiceImage { get; set; }

    }
}
