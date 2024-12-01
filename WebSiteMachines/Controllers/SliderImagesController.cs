using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.SliderImages;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SliderImagesController : Controller
	{
        #region Fields

        private readonly ISliderImagesService _sliderImagesService;
		private readonly IPhotoService _photoService;

		public SliderImagesController(ISliderImagesService sliderImagesService, IPhotoService photoService)
		{
			_sliderImagesService = sliderImagesService;
			_photoService = photoService;
		}
        #endregion

        [HttpGet, Route("/SliderImages/Index")]
        public async Task<IActionResult> Index()
		{
			var model = await _sliderImagesService.GetAll();

			var VM = new SliderImagesViewModel
			{
				SliderImages = model
			};

			return View(VM);
		}

        [HttpGet, Route("/CreateSliderImages")]
        public async Task<IActionResult> Create()
		{
			var model = new SliderImagesUpsertViewModel();

			return View(model);

		}

		[HttpPost, Route("/CreateSliderImages")]
		public async Task<IActionResult> Create(SliderImagesUpsertViewModel VM)
		{
			if (!ModelState.IsValid)
			{
				string imageUrl = null;
				if (VM.FormFileImage != null)
				{
					var result = await _photoService.AddPhotoAsync(VM.FormFileImage);
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
				var entity = new SliderImages
				{
					SliderImage = imageUrl,
					Header=VM.Header,
					Content=VM.Content,


				};
				_sliderImagesService.Add(entity);
				return RedirectToAction("Index");

			}
			else
			{
				ModelState.AddModelError("", "Photo upload failed");
			}
			return View(VM);

		}

        [HttpGet, Route("/EditSliderImages")]
        public async Task<IActionResult> Edit(int id)
		{
			var model = await _sliderImagesService.GetById(id);
			if (model == null) return View(null);

			var VM = new SliderImagesUpsertViewModel { 
				ImageUrl = model.SliderImage,
				Content = model.Content,
				Header = model.Header,
			};

			return View(VM);

		}

		[HttpPost, Route("/EditSliderImages")]
		public async Task<IActionResult> Edit(int id ,SliderImagesUpsertViewModel VM)
		{
			if (!ModelState.IsValid)
			{
				var exictingEntity = await _sliderImagesService.GetById(id);
				if (exictingEntity == null) return View(null);

				string imageUrl = exictingEntity.SliderImage;
				if (VM.FormFileImage != null)
				{
					var result = await _photoService.AddPhotoAsync(VM.FormFileImage);
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
				exictingEntity.SliderImage = imageUrl;
				exictingEntity.Content= VM.Content;
				exictingEntity.Header = VM.Header;

				_sliderImagesService.Update(exictingEntity);
				return RedirectToAction("Index");

			}
			ModelState.AddModelError("", "Invalid data provided");
			return View(VM);
		}

        [HttpGet, Route("/DeleteSliderImages")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _sliderImagesService.GetById(id);
            if (entity == null) return View("Error");

            return View(entity);
        }

        [HttpPost, ActionName("Delete") ,Route("/DeleteSliderImages")]
        public async Task<ActionResult> DeleteSlider(int id)
        {
            var entity = await _sliderImagesService.GetById(id);
            if (entity == null) return View("Error");

            _sliderImagesService.Delete(entity);
            return RedirectToAction("Index");
        }

    }
}
