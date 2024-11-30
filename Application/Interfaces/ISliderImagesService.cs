using WebSiteMachines.Models;

namespace WebSiteMachines.Interfaces
{
    public interface ISliderImagesService
    {
		Task<List<SliderImages>> GetAll();
		Task<SliderImages> GetById(int id);
		bool Add(SliderImages sliderImages);
		bool Update(SliderImages sliderImages);
		bool Delete(SliderImages sliderImages);
		bool Save();
	}
}
