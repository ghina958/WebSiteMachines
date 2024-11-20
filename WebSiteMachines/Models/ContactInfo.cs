using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }
      
        [MaxLength(500)]
        public string? Address { get; set; }

        [EmailAddress] 
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? WorkingHours { get; set; }

        public virtual ICollection<MobileNumber>? MobileNumbers { get; set; }
    }
}
