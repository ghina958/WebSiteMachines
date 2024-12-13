using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Interfaces;
using WebSiteMachines.ViewModels.ContactInfo;
using IEmailSender = WebSiteMachines.Interfaces.IEmailSender;

namespace WebSiteMachines.Controllers
{
    public class ContactInfoController : Controller
    {
        #region Fields
        private readonly IContactInfoService _contactInfoService;
		private readonly IEmailSender _emailSender;
        private readonly IPhotoService _photoService;

        public ContactInfoController(IContactInfoService contactInfoService, IEmailSender emailSender, IPhotoService photoService)
        {
            _contactInfoService = contactInfoService;
            _emailSender = emailSender;
            _photoService = photoService;
        }
        #endregion

        [HttpGet, Route("/ContactInfo/Home")]
		public async Task<IActionResult> Index()
        {
			var entity = await _contactInfoService.GetContactInfo();
			if (entity == null)
			{
				return NotFound("The Contact Info section was not found.");
			}

			var model = new ContactInfoViewModel
			{
				Address = entity.Address,
				MailUs = entity.MailUs,
				Phone1 = entity.Phone1,
				Phone2 = entity.Phone2,
				MainImagePath=entity.SliderImage
			};

			return View(model);
		}
        //[HttpPost]
        //public async Task<IActionResult> Index(ContactInfoViewModel model)
        //{
        //	if (ModelState.IsValid)
        //	{
        //		var subject = $"New message from {model.Name} ({model.Email})";
        //		var body = $"<p>{model.Message}</p>";

        //		// Send the email using IEmailSender
        //		await _emailSender.SendEmailAsync("admin@example.com", subject, body);

        //		TempData["SuccessMessage"] = "Your message has been sent successfully!";
        //		return RedirectToAction("IndexHome");
        //	}

        //	return View(model);
        //      }

        [Authorize(Roles = "Admin")]
        [HttpGet, Route("/ContactInfo/Index")]
        public async Task<IActionResult> IndexAdmin()
		{
			var entity = await _contactInfoService.GetContactInfo();
			if (entity == null)
			{
				return NotFound("The Contact Info section was not found.");
			}

			var model = new ContactInfoViewModel
			{
				Address = entity.Address,
				MailUs = entity.MailUs,
				Phone1 = entity.Phone1,
				Phone2 = entity.Phone2,
				MainImagePath=entity.SliderImage
			};

			return View(model);
		}

        [HttpPost, Route("/ContactInfo/Index")]
        public async Task<IActionResult> IndexAdmin(ContactInfoViewModel vm)
        {
			if (!ModelState.IsValid)
			{
                var entity = await _contactInfoService.GetContactInfo();
                if (entity == null)
                {
                    return NotFound("The Contact Info section was not found.");
                }
                string imageUrl = entity.SliderImage;
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

                entity.Address = vm.Address;
				entity.MailUs = vm.MailUs;
				entity.Phone1 = vm.Phone1;
				entity.Phone2 = vm.Phone2;
                entity.SliderImage = imageUrl;



                _contactInfoService.Update(entity);
				return RedirectToAction("Index", "DashboardAdmin");

			}
            return View(vm);

        }
    }
}
