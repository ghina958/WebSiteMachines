using Castle.Core.Smtp;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Interfaces;
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
		public async Task<IActionResult> Index()
        {
			//var contactUs = await _contactInfoService.GetContactInfo();
			//if (contactUs == null)
			//{
			//	return NotFound("Contact information was not found.");
			//}

			//var model = new ContactInfoViewModel
			//{
			//	Name=
			//	Email = contactUs.Email,

			//};
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(ContactInfoViewModel model)
		{
			if (ModelState.IsValid)
			{
				var subject = $"New message from {model.Name} ({model.Email})";
				var body = $"<p>{model.Message}</p>";

				// Send the email using IEmailSender
				await _emailSender.SendEmailAsync("admin@example.com", subject, body);

				TempData["SuccessMessage"] = "Your message has been sent successfully!";
				return RedirectToAction("IndexHome");
			}

			return View(model);
		}
	}
}
