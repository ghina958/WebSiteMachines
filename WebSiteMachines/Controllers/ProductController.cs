using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.FiltersModel;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSiteMachines.ViewModels.Product;

namespace WebSiteMachines.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPhotoService _photoService;
        public ProductController(IProductService productService, ICategoryService categoryService, IPhotoService photoService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _photoService = photoService;
        }


        public async Task<IActionResult> Index()
        {
            var allProduct = await _productService.GetAll(new ProductFilter());
            var model = new ProductViewModel()
            {
                products = allProduct
            };
            //var filter = new ProductFilter();
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

        [HttpPost]
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
        public async Task<IActionResult> Create()
        {
            var model = new ProductUpsertViewModel();
            //ViewBag.Title = "Add" + model.Name;
            //ViewBag.BreadCrumbFirstItem = "Product List";
            //ViewBag.BreadCrumbFirstItemLink = "/product";
            //ViewBag.BreadCrumbSecondItem = "Add";
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

        [HttpPost]
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

        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            //ViewBag.Title = "Edit " + product.Name;
            //ViewBag.BreadCrumbFirstItem = "Products List";
            //ViewBag.BreadCrumbFirstItemLink = "/product";
            //ViewBag.BreadCrumbSecondItem = "Edit";
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

        [HttpPost]
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



    }
}
