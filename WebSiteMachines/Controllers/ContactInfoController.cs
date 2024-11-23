using Castle.Core.Smtp;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Repositories;
using WebSiteMachines.ViewModels.AboutUs;
using WebSiteMachines.ViewModels.ContactInfo;
using IEmailSender = WebSiteMachines.Interfaces.IEmailSender;

namespace WebSiteMachines.Controllers
{
    public class ContactInfoController : Controller
    {
		private readonly IContactInfoService _contactInfoService;
		private readonly IEmailSender _emailSender;


		public ContactInfoController(IContactInfoService contactInfoService, IEmailSender emailSender)
		{
			_contactInfoService = contactInfoService;
			_emailSender = emailSender;
		}

		[HttpGet]
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
				Phone2 = entity.Phone2
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
				Phone2 = entity.Phone2
			};

			return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> IndexAdmin(ContactInfoViewModel vm)
        {
			if (ModelState.IsValid)
			{
                var entity = await _contactInfoService.GetContactInfo();
                if (entity == null)
                {
                    return NotFound("The Contact Info section was not found.");
                }

				entity.Address = vm.Address;
				entity.MailUs = vm.MailUs;
				entity.Phone1 = vm.Phone1;
				entity.Phone2 = vm.Phone2;


				_contactInfoService.Update(entity);
                TempData["SuccessMessage"] = "The About Us section was updated successfully.";
                return RedirectToAction("Index");

            }
            return View(vm);

        }
    }
}
