using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.Interfaces;

namespace WebSiteMachines.Repositories
{
	public class SliderImagesService : ISliderImagesService
	{
		private readonly ApplicationDbContext _context;
		public SliderImagesService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<List<Models.SliderImages>> GetAll()
		{
			return await _context.SliderImages.ToListAsync();
		}

		public async Task<Models.SliderImages> GetById(int id)
		{
			return await _context.SliderImages.FirstOrDefaultAsync(i => i.Id == id);
		}

		public bool Add(Models.SliderImages sliderImages)
		{
			_context.SliderImages.Add(sliderImages);
			return Save();
		}

		public bool Delete(Models.SliderImages sliderImages)
		{
			_context.SliderImages.Remove(sliderImages);
			return Save();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Models.SliderImages sliderImages)
		{
			_context.SliderImages.Update(sliderImages);
			return Save();
		}
	}
}
