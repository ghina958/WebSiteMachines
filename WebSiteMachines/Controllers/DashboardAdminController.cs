using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Interfaces;
using WebSiteMachines.ViewModels.DashBoard;

namespace WebSiteMachines.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardAdminController : Controller
	{
        #region Fields
        private readonly IDashboardAdminService _dashboardAdminService;

        public DashboardAdminController(IDashboardAdminService dashboardAdminService)
        {
            _dashboardAdminService = dashboardAdminService;
        }
        #endregion

        [HttpGet , Route("/Dashboard/Index")]
        public async Task<IActionResult> Index()
        {
            var countOfAllCategories = await _dashboardAdminService.GetCategoriesCount();
            var countOfAllProducts = await _dashboardAdminService.GetProductCount();
            var countOfContactUs = await _dashboardAdminService.GetContactCount();

            var CountVM = new DashBoardViewModel()
            {
                CategoriesAmount = countOfAllCategories,
                ContactsAmount = countOfContactUs,
                ProductsAmount = countOfAllProducts,
            };
            return View(CountVM);
        }
	}
}
