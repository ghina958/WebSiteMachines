using Microsoft.AspNetCore.Mvc;

namespace WebSiteMachines.Controllers
{
    public class ContactInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
