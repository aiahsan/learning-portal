using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Learning.Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Portal.Controllers
{
    [Authorize(Roles = Role.Admin + ","+ Role.Teacher + "," + Role.Parent)]
    public class UsersController : BaseController
    {
        private readonly LearningDbContext _db = null;
        private readonly UserManager<User> _userManager;
        public UsersController(UserManager<User> userManager, LearningDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(UsersByRole(_db));
        }
        public ActionResult Create()
        {
            ViewData["Roles"] = GetRoles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterVM userViewModel)
        {
            if (ModelState.IsValid)
            {
                // See if user-name is unique...
                var existingUser = await _userManager.FindByNameAsync(userViewModel.UserName);

                if (existingUser == null)
                {
                    var user = new User
                    {
                        UserName = userViewModel.UserName,
                        FirstName = userViewModel.FirstName,
                        LastName = userViewModel.LastName,
                        Email = userViewModel.Email,
                        PhoneNumber = userViewModel.PhoneNumber,
                        Address = userViewModel.Address,
                        EmailConfirmed = true,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = CurrentUser(_db)
                    };

                    var adminresult = await _userManager.CreateAsync(user, userViewModel.Password);
                    if (adminresult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, userViewModel.Type);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User not created");
                        return View(userViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "A user with this 'UserName' already exists");
                    return View(userViewModel);
                }
            }
            return RedirectToAction("DataError", "Error");
        }

        public ActionResult Edit(int id)
        {
            var user = UserByRole(id, _db);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return RedirectToAction("Index");
            }
            return View(new UpdateVM()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UpdateVM userViewModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = UserByRole(userViewModel.Id, _db);

                if (existingUser != null)
                {
                    existingUser.FirstName = userViewModel.FirstName;
                    existingUser.LastName = userViewModel.LastName;
                    existingUser.PhoneNumber = userViewModel.PhoneNumber;
                    existingUser.Address = userViewModel.Address;
                    existingUser.Email = userViewModel.Email;

                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "User not found!");
                    return View(userViewModel);
                }
            }
            return RedirectToAction("DataError", "Error");
        }

        public ActionResult Details(int id)
        {
            var user = UserByRole(id, _db);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return RedirectToAction("Index");
            }
            return View(new RegisterVM()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                //Type = user.Role.Name,
                UserName = user.UserName
            });
        }
    }
}