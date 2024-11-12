using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Interfaces;
using WebSiteMachines.ViewModels.DashBoard;

namespace WebSiteMachines.Controllers
{
	public class DashboardAdminController : Controller
	{
        private readonly IDashboardAdminService _dashboardAdminService;

        public DashboardAdminController(IDashboardAdminService dashboardAdminService)
        {
            _dashboardAdminService = dashboardAdminService;
        }


        public async Task<IActionResult> Index()
        {
            var countOfAllCategories = await _dashboardAdminService.GetCategoriesCount();
            var countOfAllUsers = await _dashboardAdminService.GetUsersCount();
            var countOfAllProducts = await _dashboardAdminService.GetProductCount();

            var CountVM = new DashBoardViewModel()
            {
                CategoriesAmount = countOfAllCategories,
                UsersAmount = countOfAllUsers,
                ProductsAmount = countOfAllProducts,


            };
            return View(CountVM);
        }
	}
}
