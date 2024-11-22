using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }
      
        [MaxLength(100)]
		public string FullName { get; set; }

		[EmailAddress] 
        [MaxLength(100)]
		public string Email { get; set; }

		[MaxLength(300)]
		public string Message { get; set; }




	}
}
