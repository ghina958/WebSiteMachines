using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Product;

namespace WebSiteMachines.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetAll(ProductSearchViewModel? productSearchViewModel = null);
		Task<Product?> GetProductByIdAsync(int id);
		Task<Product?> GetByIdAsyncNoTracking(int id);
		bool Add(Product product);
		bool Update(Product product);
		bool Delete(Product product);
		bool Save();
	}
}
