using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GymTerminatorApp.Models;

namespace GymTerminatorApp.Controllers
{
    
    public class RegistroController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegistroController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel model, string selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("Cliente"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Cliente"));
                    }
                    if (!await _roleManager.RoleExistsAsync("Entrenador"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Entrenador"));
                    }

                    if (selectedRole == "Cliente")
                    {
                        await _userManager.AddToRoleAsync(user, "Cliente");
                    }
                    else if (selectedRole == "Entrenador")
                    {
                        await _userManager.AddToRoleAsync(user, "Entrenador");
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
