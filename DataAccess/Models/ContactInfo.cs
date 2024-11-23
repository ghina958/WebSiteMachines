using System.ComponentModel.DataAnnotations;

namespace WebSiteMachines.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }
      
  //      [MaxLength(100)]
		//public string FullName { get; set; }

		//[EmailAddress] 
		//public string Email { get; set; }

		//[MaxLength(300)]
		//public string Message { get; set; }

		[MaxLength(300)]
		public string Address { get; set; }

		[EmailAddress]
		public string MailUs { get; set; }

		[DataType(DataType.PhoneNumber)]
		[MaxLength(15)]
		public string Phone1 { get; set; }

		[DataType(DataType.PhoneNumber)]
		[MaxLength(15)]
		public string? Phone2 { get; set; }	
	}
}
