using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Category;

namespace WebSiteMachines.Interfaces
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAllCategories(CategorySearchViewModel? categorySearchViewModel = null);

        Task<Category> GetCategoryById(int id);
		bool Add(Category category);
		bool Update(Category category);
		bool Delete(Category category);
		bool Save();
	}
}
