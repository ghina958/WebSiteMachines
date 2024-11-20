using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteMachines.Models
{
    public class MobileNumber
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [Phone] 
        [MaxLength(20)]
        public string Number { get; set; }

        [ForeignKey("ContactInfo")]
        public int ContactInfoId { get; set; }
        public ContactInfo? ContactInfo { get; set; }
    }
}
