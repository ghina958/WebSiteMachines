using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Login;

namespace WebSiteMachines.Controllers
{
    public class AuthController : Controller
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        //private readonly ApplicationDbContext _context;

        public AuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<HomeController> logger)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
		#endregion

		
        [HttpGet ,Route("/Admin")]
		public ActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }
       
        [HttpPost, Route("/Admin")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "DashboardAdmin");
                    }
                }
                //password is incorrect
                //TempData["Error"] = "Wrong credintails please try again ";
                ModelState.AddModelError("", "User Name or Password is not correct , please try again ");
                return View(loginModel);
            }
            //User not found
            //TempData["Error"] = "Wrong credintails please try again ";
            return RedirectToAction("AccessDenied");
        }

        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }

        public IActionResult AccessDenied()
        {
            return View(); // Inform users they lack sufficient permissions
        }
    }
}
