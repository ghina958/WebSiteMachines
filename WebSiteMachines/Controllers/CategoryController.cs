using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.FiltersModel;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Category;
using WebSiteMachines.ViewModels.Product;


namespace WebSiteMachines.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

		public CategoryController(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}



		public async Task<IActionResult> DropdownSolution()
        {
            var all = await _categoryService.GetAllCategories(new CategoryFilter ());
			
			var model = new CategoryViewModel()
            {
                Categories = all
            };

			return PartialView("_SelectListNav", model);
		}

		public async Task<IActionResult> DropdownSolutionİtems(int id)
		{
			if (id <= 0)
			{
				return NotFound("Invalid category ID.");
			}
			var allProduct = await _productService.GetAll(new ProductFilter { CategoryId = id });
			var model = new ProductViewModel()
			{
				products = allProduct
			};
			return View(model);
		}
		




		public async Task<IActionResult> Index()
        {
            var allcategory = await _categoryService.GetAllCategories(new CategoryFilter());
            ViewBag.BreadCrumbFirstItem = "Category List";
            ViewBag.BreadCrumbFirstItemLink = "/category";
            var model = new CategoryViewModel()
            {
                Categories = allcategory
            };
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> Index(CategoryFilter filter)
        {
            var allcategory = await _categoryService.GetAllCategories(filter);
            var model = new CategoryViewModel()
            {
                Categories = allcategory
            };
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CategoryUpsertViewModel();
            ViewBag.Title = "Add" + model.Name;
            ViewBag.BreadCrumbFirstItem = "Category List";
            ViewBag.BreadCrumbFirstItemLink = "/category";
            ViewBag.BreadCrumbSecondItem = "Add";

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryUpsertViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = Vm.Name,

                };
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            return View(Vm);
        }
   
        public async Task<ActionResult> Edit(int id)
        {
            var cat = await _categoryService.GetCategoryById(id);
            if (cat == null) return View("Error");
            ViewBag.Title = "Edit " + cat.Name;
            ViewBag.BreadCrumbFirstItem = "Category List";
            ViewBag.BreadCrumbFirstItemLink = "/category";
            ViewBag.BreadCrumbSecondItem = "Edit";

            var categoryVM = new CategoryUpsertViewModel
            {
                Name = cat.Name

            };
            return View(categoryVM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, CategoryUpsertViewModel Vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "failed to edit category");
                return View("Edit", Vm);
            }

            var category = new Category
            {
                Id = id,
                Name = Vm.Name,
            };
           
            _categoryService.Update(category);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cat = await _categoryService.GetCategoryById(id);
            if (cat == null) return View("Error");

            ViewBag.Title = "Delete " + cat.Name;
            ViewBag.BreadCrumbFirstItem = "Category List";
            ViewBag.BreadCrumbFirstItemLink = "/category";
            ViewBag.BreadCrumbSecondItem = "Delete";
            return View(cat);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var cat = await _categoryService.GetCategoryById(id);
            if (cat == null) { return View("Error"); }

            _categoryService.Delete(cat);
            return RedirectToAction("Index");
        }


    }
}
