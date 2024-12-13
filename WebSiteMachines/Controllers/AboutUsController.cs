using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Interfaces;
using WebSiteMachines.ViewModels.AboutUs;

namespace WebSiteMachines.Controllers
{
    public class AboutUsController : Controller
    {
        #region Fields
        private readonly IAboutUsService _aboutUsService;
		private readonly IPhotoService _photoService;

		public AboutUsController(IAboutUsService aboutUsService, IPhotoService photoService)
		{
			_aboutUsService = aboutUsService;
			_photoService = photoService;
		}
        #endregion

        #region Admin manage of about Us Area
        [Authorize(Roles = "Admin")]

        [HttpGet, Route("/AboutUs/Index")]
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
            };

            return View(model);
        }

        [HttpPost, Route("/AboutUs/Index")]
        public async Task<IActionResult> Index(AboutUsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var entity = await _aboutUsService.GetById();
                if (entity == null)
                {
                    return NotFound("The About Us section was not found.");
                }

				string imageUrl = entity.ImagePath;
				if (vm.MainImage != null)
				{
					var result = await _photoService.AddPhotoAsync(vm.MainImage); // Upload the new image
					if (result != null && result.Url != null)
					{
						imageUrl = result.Url.ToString();
					}
					else
					{
						ModelState.AddModelError("", "Photo upload failed");
						return View(vm);
					}

				}

				entity.Title = vm.Title;
                entity.Description = vm.Description;
                entity.ImagePath = imageUrl;

                _aboutUsService.Update(entity);
				return RedirectToAction("Index" , "DashboardAdmin");
			}
            return View(vm);
        }
        #endregion


        [HttpGet, Route("/AboutUs/Home")]
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
			};

			return View(model);

        }

    }
}




//[HttpPost]
//public async Task<IActionResult> Index(AboutUsViewModel vm)
//{
//	if (ModelState.IsValid)
//	{
//		var aboutUs = await _aboutUsService.GetById();
//		if (aboutUs == null)
//		{
//			return NotFound("The About Us section was not found.");
//		}

//		aboutUs.Title = vm.Title;
//		aboutUs.Description = vm.Description;

//		if (vm.MainImage != null)
//		{
//			// Define the path where the image will be saved
//			var mainImagePath = Path.Combine("wwwroot/images/AboutUs", vm.MainImage.FileName);
//			using (var stream = new FileStream(mainImagePath, FileMode.Create))
//			{
//				vm.MainImage.CopyTo(stream); // Save the uploaded file
//			}

//			// Update the database record with the new path
//			aboutUs.ImagePath = $"/images/{vm.MainImage.FileName}";
//		}
//		// Handle additional image uploads
//		if (vm.AdditionalImages != null && vm.AdditionalImages.Any())
//		{
//			// Initialize or clear the existing list of additional image paths
//			aboutUs.AdditionalImagePaths = new List<string>();

//			foreach (var image in vm.AdditionalImages)
//			{
//				// Define the path where each image will be saved
//				var imagePath = Path.Combine("wwwroot/images/AboutUs", image.FileName);
//				using (var stream = new FileStream(imagePath, FileMode.Create))
//				{
//					image.CopyTo(stream); // Save each uploaded file
//				}

//				// Add the new image path to the list
//				aboutUs.AdditionalImagePaths.Add($"/images/{image.FileName}");
//			}
//		}
//		_aboutUsService.Update(aboutUs);
//		TempData["SuccessMessage"] = "The About Us section was updated successfully.";
//		return RedirectToAction("IndexHome");

//	}
//	return View(vm);
//}