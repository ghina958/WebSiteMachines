using WebSiteMachines.Models;

namespace WebSiteMachines.Interfaces
{
	public interface IUserService
	{
		//Task<List<ApplicationUser>> GetAll(CustomerSearchViewModel? customerSearchViewModel = null);
		Task<ApplicationUser?> GetByIdAsync(string id);
		bool Add(ApplicationUser appCustomer);
		bool Update(ApplicationUser appCustomer);
		bool Delete(ApplicationUser appCustomer);
		bool Save();
	}
}
