using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Login;

namespace WebSiteMachines.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly ApplicationDbContext _context;

        #region Ctor
        public AuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        public ActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }
        //Auth/Login
        [HttpPost]
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
                TempData["Error"] = "Wrong credintails please try again ";
                return View(loginModel);
            }
            //User not found
            TempData["Error"] = "Wrong credintails please try again ";
            return View(loginModel);
        }

    }
}
