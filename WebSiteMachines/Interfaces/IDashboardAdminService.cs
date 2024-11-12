namespace WebSiteMachines.Interfaces
{
	public interface IDashboardAdminService
	{
		Task<int> GetProductCount();
		Task<int> GetCategoriesCount();
		Task<int> GetUsersCount();
	}
}
