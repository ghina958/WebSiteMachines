namespace WebSiteMachines.ViewModels.ContactInfo
{
	public class ContactInfoViewModel
	{
		//public string Name { get; set; }
		//public string Email { get; set; }
		//public string Message { get; set; }

        public string Address { get; set; }

        public string MailUs { get; set; }
        public string Phone1 { get; set; }

        public string? Phone2 { get; set; }

        public IFormFile? MainImage { get; set; }
        public string MainImagePath { get; set; }
    }
}
