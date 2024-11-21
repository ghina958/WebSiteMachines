using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Category;

namespace WebSiteMachines.Interfaces
{
	public interface IAboutUsService
	{
		Task<List<AboutUs>> GetAll();
		Task<AboutUs> GetById();
		//bool Add(AboutUs aboutUs);
		bool Update(AboutUs aboutUs);
		bool Save();
	}
}
