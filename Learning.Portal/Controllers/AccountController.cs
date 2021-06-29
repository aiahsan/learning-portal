using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Learning.Portal.ViewModels;
using Learning.Portal.Context;
using Microsoft.AspNetCore.Identity;
using Learning.Portal.Models;
using Microsoft.Extensions.Options;

namespace Learning.Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly LearningDbContext _learningDbContext;
        public AccountController(
           UserManager<User> userManager,
           RoleManager<IdentityRole<int>> roleManager,
           SignInManager<User> signInManager,
           LearningDbContext _database
           )
        {
            _learningDbContext = _database;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task < IActionResult> Login(string returnUrl = "")
        {
            /*

            var role = new IdentityRole<int>();
            role.Name = "Admin";
            await _roleManager.CreateAsync(role);

            //Here we create a Admin super user who will maintain the website                   

            var userx = new User();
            userx.UserName = "ahsan";
            userx.Email = "ahsan@gmail.com";

            string userPWD = "AhsanIsmail199715.";

            IdentityResult chkUser = await _userManager.CreateAsync(userx, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result1 = await _userManager.AddToRoleAsync(userx, "Admin");
            }
            */

            string user = HttpContext.User?.Identity?.Name ?? null;

            if (!string.IsNullOrWhiteSpace(user))
                return  RedirectToAction("Portal", "Home");

            var model = new LoginVM { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            await DbInitilizer.Init(_userManager, _roleManager, _learningDbContext);
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Portal", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect(returnUrl ?? "/Account/Login");
        }
    }
}