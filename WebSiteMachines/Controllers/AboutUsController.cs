﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Repositories;
using WebSiteMachines.ViewModels.AboutUs;
using WebSiteMachines.ViewModels.Category;

namespace WebSiteMachines.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }


        #region Admin manage of about Us Area
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var aboutUs = await _aboutUsService.GetById();
            if (aboutUs == null)
            {
                return NotFound("The About Us section was not found.");
            }

            var model = new AboutUsViewModel
            {
                Title = aboutUs.Title,
                Description = aboutUs.Description,
                MainImagePath = aboutUs.ImagePath,
                AdditionalImagePaths = aboutUs.AdditionalImagePaths?.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AboutUsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var aboutUs = await _aboutUsService.GetById();
                if (aboutUs == null)
                {
                    return NotFound("The About Us section was not found.");
                }

                aboutUs.Title = vm.Title;
                aboutUs.Description = vm.Description;

                if (vm.MainImage != null)
                {
                    // Define the path where the image will be saved
                    var mainImagePath = Path.Combine("wwwroot/images/AboutUs", vm.MainImage.FileName);
                    using (var stream = new FileStream(mainImagePath, FileMode.Create))
                    {
                        vm.MainImage.CopyTo(stream); // Save the uploaded file
                    }

                    // Update the database record with the new path
                    aboutUs.ImagePath = $"/images/{vm.MainImage.FileName}";
                }
                // Handle additional image uploads
                if (vm.AdditionalImages != null && vm.AdditionalImages.Any())
                {
                    // Initialize or clear the existing list of additional image paths
                    aboutUs.AdditionalImagePaths = new List<string>();

                    foreach (var image in vm.AdditionalImages)
                    {
                        // Define the path where each image will be saved
                        var imagePath = Path.Combine("wwwroot/images/AboutUs", image.FileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            image.CopyTo(stream); // Save each uploaded file
                        }

                        // Add the new image path to the list
                        aboutUs.AdditionalImagePaths.Add($"/images/{image.FileName}");
                    }
                }
				 _aboutUsService.Update(aboutUs);
				TempData["SuccessMessage"] = "The About Us section was updated successfully.";
                return RedirectToAction("IndexHome");

            }
            return View(vm);
        }


        #endregion


        [HttpGet]
        public async Task<IActionResult> IndexHome()
        {
            var aboutUs = await _aboutUsService.GetById();
            if (aboutUs == null)
            {
                return NotFound("The About Us section was not found.");
            }
			var model = new AboutUsViewModel
			{
				Title = aboutUs.Title,
				Description = aboutUs.Description,
				MainImagePath = aboutUs.ImagePath,
				AdditionalImagePaths = aboutUs.AdditionalImagePaths?.ToList()
			};

			return View(model);

        }

    }
}