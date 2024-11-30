using Microsoft.AspNetCore.Http;
namespace WebSiteMachines.ViewModels.AboutUs
{
	public class AboutUsViewModel
	{
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? MainImage { get; set; } 
        public string MainImagePath { get; set; } 

    }
}
