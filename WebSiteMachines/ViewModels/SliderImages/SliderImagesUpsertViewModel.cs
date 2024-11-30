namespace Web.ViewModels.SliderImages
{
	public class SliderImagesUpsertViewModel
	{
		public int? Id { get; set; }
		public IFormFile? FormFileImage { get; set; }
		public string ImageUrl { get; set; }
		public string Header { get; set; }
		public string Content { get; set; }
	}
}
