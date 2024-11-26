using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
     public class OurTeam
     {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)] 
        public string position { get; set; } 

        [MaxLength(255)]
        public string Image { get; set; }



    }
}
