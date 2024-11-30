using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.OurTeam;
using Web.ViewModels.SliderImages;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.Repositories;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SliderImagesController : Controller
	{
		private readonly ISliderImagesService _sliderImagesService;
		private readonly IPhotoService _photoService;

		public SliderImagesController(ISliderImagesService sliderImagesService, IPhotoService photoService)
		{
			_sliderImagesService = sliderImagesService;
			_photoService = photoService;
		}
		public async Task<IActionResult> Index()
		{
			var model = await _sliderImagesService.GetAll();

			var VM = new SliderImagesViewModel
			{
				SliderImages = model
			};

			return View(VM);
		}

		public async Task<IActionResult> Create()
		{
			var model = new SliderImagesUpsertViewModel();

			return View(model);

		}

		[HttpPost]
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

		[HttpPost]
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
	}
}
