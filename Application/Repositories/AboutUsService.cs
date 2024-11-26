using WebSiteMachines.Data;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;

namespace WebSiteMachines.Repositories
{
	public class AboutUsService : IAboutUsService
	{
		private readonly ApplicationDbContext _context;
		public AboutUsService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<List<AboutUs>> GetAll()
		{
			return _context.AboutUs.ToList();
		}
		public async Task<AboutUs> GetById()
		{
			return  _context.AboutUs.FirstOrDefault();
		}

		//public bool Add(AboutUs aboutUs)
		//{
		//	_context.AboutUs.Add(aboutUs);
		//	return Save();
		//}
		public bool Update(AboutUs aboutUs)
		{
			_context.AboutUs.Update(aboutUs);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		
	}
}
