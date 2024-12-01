using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.FiltersModel;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSiteMachines.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;

namespace WebSiteMachines.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPhotoService _photoService;
        public ProductController(IProductService productService, ICategoryService categoryService, IPhotoService photoService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _photoService = photoService;
        }
        #endregion

        [HttpGet, Route("/Product/Index")]
		public async Task<IActionResult> Index()
        {
            var allProduct = await _productService.GetAll(new ProductFilter());
            var model = new ProductViewModel()
            {
                products = allProduct
            };
            var categories = await _categoryService.GetAllCategories(new CategoryFilter());

            foreach (var item in categories)
            {
                model.AvailableCategories.Add(
                    new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    }
                    );
            }
            return View(model);
        }

        [HttpPost, Route("/Product/Index")]
        public async Task<IActionResult> Index(ProductFilter filter)
        {
            var allProduct = await _productService.GetAll(filter);
            var model = new ProductViewModel()
            {
                products = allProduct

            };   
            var categories = await _categoryService.GetAllCategories(new CategoryFilter());
            foreach (var item in categories)
            {
                model!.AvailableCategories.Add(
                    new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    }
                    );
            }
            return View(model);

        }

		[HttpGet, Route("/CreateProduct")]
		public async Task<IActionResult> Create()
        {
            var model = new ProductUpsertViewModel();
            var categories = await _categoryService.GetAllCategories(new CategoryFilter());
            foreach (var item in categories)
            {
                model.Categories.Add(
                    new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    }
                    );
            }
            return View(model);
        }

        [HttpPost, Route("/CreateProduct")]
        public async Task<IActionResult> Create(ProductUpsertViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = null; 

                // Check if there is an image to upload
                if (productVM.Image != null)
                {
                    var result = await _photoService.AddPhotoAsync(productVM.Image);
                    if (result != null && result.Url != null)
                    {
                        imageUrl = result.Url.ToString(); // Save the image URL if the upload is successful
                    }
                    else
                    {
                        ModelState.AddModelError("", "Photo upload failed");
                        return View(productVM); // Return to the view if the upload fails
                    }
                }

                var product = new Product
                {
                    Name = productVM.Name,
                    Description = productVM.Description,
                    ProductImage = imageUrl,
                    CategoryId = productVM.CategoryId
                    

                };
                _productService.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(productVM);
        }

		[HttpGet, Route("/EditProduct")]
		public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            var categories = await _categoryService.GetAllCategories(new CategoryFilter() );
            var VM = new ProductUpsertViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CurrentImageUrl = product.ProductImage,
                CategoryId = product.CategoryId,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name

                }).ToList()

            };
           
            return View(VM);
        }

        [HttpPost, Route("/EditProduct")]
        public async Task<IActionResult> Edit(int id, ProductUpsertViewModel VM)
        {
            if (ModelState.IsValid)
            {
               
                var existingProduct = await _productService.GetByIdAsyncNoTracking(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                string imageUrl = existingProduct.ProductImage;

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
                else
                {
                    imageUrl = existingProduct.ProductImage; // Keep the old image if no new image is uploaded
                }
                existingProduct.Name = VM.Name;
                existingProduct.Description = VM.Description;
                existingProduct.ProductImage = imageUrl;
                existingProduct.CategoryId = VM.CategoryId;

                _productService.Update(existingProduct);

                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Invalid data provided");
            return View(VM);
        }

		[HttpGet, Route("/DeleteProduct")]
		public async Task<ActionResult> Delete(int id)
		{
			var entity = await _productService.GetProductByIdAsync(id);
			if (entity == null) return View("Error");
			ViewBag.Title = "Delete " + entity.Name;
			return View(entity);
		}


		[HttpPost, ActionName("Delete"), Route("/DeleteProduct")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var entity = await _productService.GetProductByIdAsync(id);
			if (entity == null) { return View("Error"); }

			_productService.Delete(entity);
			return RedirectToAction("Index");
		}


	}
}
