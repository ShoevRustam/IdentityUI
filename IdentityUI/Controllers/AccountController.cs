using IdentityUI.Models;
using IdentityUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
           return await Task.Run(() => View());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginVm login)
        {
            if (!ModelState.IsValid) return View();
            var dbUser = await _userManager.FindByNameAsync(login.UserName);
            if (dbUser == null)
            {
                ModelState.AddModelError("", "UserName or Password invalid");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(dbUser, login.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", login.UserName + " is lockout");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password invalid");
                return View();
            }

            var roles = await _userManager.GetRolesAsync(dbUser);
            if (roles[0] == "Admin")
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new ApplicationUser
            {
                FullName = register.FullName,
                UserName = register.UserName,
                Email = register.Email

            };

            var model = await _userManager.CreateAsync(user, register.Password);

            if (!model.Succeeded)
            {
                foreach (var error in model.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            };
            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, true);


            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> AccessDenied()
        {
            return await Task.Run(() => View());
        }
    }
}
