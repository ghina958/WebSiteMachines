using WebSiteMachines.Data;
using WebSiteMachines.Interfaces;

namespace WebSiteMachines.Repositories
{
	public class DashboardAdminService : IDashboardAdminService
	{
		private readonly ApplicationDbContext _context;
		public DashboardAdminService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<int> GetCategoriesCount()
		{
			var count = _context.Category.Count();

			return count;
		}
		public async Task<int> GetProductCount()
		{
			var count = _context.Product.Count();

			return count;
		}
		public async Task<int> GetUsersCount()
		{
			var count = _context.Users.Count();

			return count;
		}
	}
}
