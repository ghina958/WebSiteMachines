using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Category;
using WebSiteMachines.ViewModels.Product;
using static System.Net.Mime.MediaTypeNames;

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
            var allProduct = await _productService.GetAll();
            ViewBag.BreadCrumbFirstItem = "Products List";
            ViewBag.BreadCrumbFirstItemLink = "/product";

            var model = new ProductViewModel()
            {
                products = allProduct
            };
            var categories = await _categoryService.GetAllCategories();
            foreach (var item in categories)
            {
                model.productSearchViewModel!.AvailableCategories.Add(
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
        public async Task<IActionResult> Index(ProductSearchViewModel productSearchViewModel)
        {
            var allProduct = await _productService.GetAll(productSearchViewModel);
            var model = new ProductViewModel()
            {
                products = allProduct

            };
            var categories = await _categoryService.GetAllCategories();
            foreach (var item in categories)
            {
                model.productSearchViewModel!.AvailableCategories.Add(
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
            ViewBag.BreadCrumbFirstItem = "Product List";
            ViewBag.BreadCrumbFirstItemLink = "/product";
            ViewBag.BreadCrumbSecondItem = "Add";
            var categories = await _categoryService.GetAllCategories();
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
                string imageUrl = null; // Declare a variable to hold the image URL

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
                    Image = imageUrl,
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

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var product = await _productService.GetProductByIdAsync(id);
        //    if (product == null) return View("Error");

        //    ViewBag.Title = "Edit " + product.Name;
        //    ViewBag.BreadCrumbFirstItem = "Products List";
        //    ViewBag.BreadCrumbFirstItemLink = "/product";
        //    ViewBag.BreadCrumbSecondItem = "Edit";

        //    var VM = new ProductUpsertViewModel
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        CurrentImageUrl = product.Image,
        //        CategoryId = product.CategoryId,

        //    };
        //    var categories = await _categoryService.GetAllCategories();
        //    foreach (var item in categories)
        //    {
        //        VM.Categories.Add(
        //            new SelectListItem
        //            {
        //                Text = item.Name,
        //                Value = item.Id.ToString()
        //            }
        //            );
        //    }
        //    return View(VM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, ProductUpsertViewModel VM)
        //{
        //    if (!ModelState.IsValid)
        //    {
               
        //        string imageUrl = VM.CurrentImageUrl;

        //        if (VM.Image != null)
        //        {
        //            var result = await _photoService.AddPhotoAsync(VM.Image); // Upload the new image
        //            imageUrl = result.Url.ToString();

        //        }
        //        var ProductEdit = await _productService.GetProductByIdAsync(id);
        //        if (ProductEdit != null)
        //        {
        //            ProductEdit.Name = VM.Name;
        //            ProductEdit.Description = VM.Description;
        //            ProductEdit.Image = imageUrl;// Update the image URL (either new or existing)
        //            ProductEdit.CategoryId = VM.CategoryId;

        //            _productService.Update(ProductEdit);

        //            // Redirect to the product index or wherever you need after successful update
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    var categories = await _categoryService.GetAllCategories();
        //    VM.Categories = categories.Select(item => new SelectListItem
        //    {
        //        Text = item.Name,
        //        Value = item.Id.ToString(),
        //        Selected = item.Id == VM.CategoryId // Select the correct category
        //    }).ToList();

        //    return View(VM);
        //}
            


    }
}
