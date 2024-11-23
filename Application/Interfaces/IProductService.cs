using WebSiteMachines.FiltersModel;
using WebSiteMachines.Models;


namespace WebSiteMachines.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetAll(ProductFilter filter);
		Task<Product?> GetProductByIdAsync(int id);
		Task<Product?> GetByIdAsyncNoTracking(int id);
		bool Add(Product product);
		bool Update(Product product);
		bool Delete(Product product);
		bool Save();
	}
}
