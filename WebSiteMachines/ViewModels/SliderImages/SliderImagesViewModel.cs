namespace Web.ViewModels.SliderImages
{
	public class SliderImagesViewModel
	{
        public SliderImagesViewModel()
        {
			SliderImages = new List<WebSiteMachines.Models.SliderImages>();

		}
        public List<WebSiteMachines.Models.SliderImages>? SliderImages { get; set; }
	}
}
