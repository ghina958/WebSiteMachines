using WebSiteMachines.FiltersModel;
using WebSiteMachines.Models;

namespace WebSiteMachines.Interfaces
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAllCategories(CategoryFilter filter);

        Task<Category> GetCategoryById(int id);
		bool Add(Category category);
		bool Update(Category category);
		bool Delete(Category category);
		bool Save();
	}
}
