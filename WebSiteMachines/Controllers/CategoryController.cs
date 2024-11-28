using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.FiltersModel;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.Repositories;
using WebSiteMachines.ViewModels.Category;
using WebSiteMachines.ViewModels.Product;


namespace WebSiteMachines.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IPhotoService _photoService;

        public CategoryController(ICategoryService categoryService, IProductService productService, IPhotoService photoService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _photoService = photoService;
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



        #region Admin area

        public async Task<IActionResult> Index()
        {
            var allcategory = await _categoryService.GetAllCategories(new CategoryFilter());
            //ViewBag.BreadCrumbFirstItem = "Category List";
            //ViewBag.BreadCrumbFirstItemLink = "/category";
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
            //ViewBag.Title = "Add" + model.Name;
            //ViewBag.BreadCrumbFirstItem = "Category List";
            //ViewBag.BreadCrumbFirstItemLink = "/category";
            //ViewBag.BreadCrumbSecondItem = "Add";

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryUpsertViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = null;
                if (Vm.Image != null)
                {
                    var result = await _photoService.AddPhotoAsync(Vm.Image);
                    if (result != null && result.Url != null)
                    {
                        imageUrl = result.Url.ToString(); 
                    }
                    else
                    {
                        ModelState.AddModelError("", "Photo upload failed");
                        return View(Vm); 
                    }
                }
                var category = new Category
                {
                    Name = Vm.Name,
                    Description= Vm.Description,
                    CategoryImage= imageUrl

				};
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(Vm);
        }
   
        public async Task<ActionResult> Edit(int id)
        {
            Category category = await _categoryService.GetCategoryById(id);
            if (category == null) return NotFound();
           

            var VM = new CategoryUpsertViewModel
            {
                Name = category.Name,
                Description = category.Description,
                CurrentImageUrl = category.CategoryImage,

            };
            return View(VM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, CategoryUpsertViewModel VM)
        {
            if (ModelState.IsValid)
            {
                var exitingCategory =await _categoryService.GetCategoryById(id);
                if(exitingCategory == null) return NotFound();

                string imageUrl = exitingCategory.CategoryImage;

                if (VM.Image != null)
                {
                    var result = await _photoService.AddPhotoAsync(VM.Image); // Upload the new image
                    if (result != null && result.Url != null)
                    {
                        imageUrl = result.Url.ToString();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Photo upload failed");
                        return View(VM);
                    }

                }
                exitingCategory.Name= VM.Name;
                exitingCategory.Description= VM.Description;
                exitingCategory.CategoryImage = imageUrl;

                _categoryService.Update(exitingCategory);
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Invalid data provided");
            return View(VM);
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

        #endregion
    }
}
