using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Learning.Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
    public class AssignStudentController: BaseController
    {

        private readonly LearningDbContext _db = null;
        private readonly UserManager<User> _userManager;
        public AssignStudentController(UserManager<User> userManager, LearningDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Assigns.Include(x => x.User).Include(x=>x.User1).ToList());

        }


        public ActionResult Create()
        {

            ViewBag.users = UsersByRole(_db);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Assign assign)
        {
            ViewBag.users = UsersByRole(_db);

            if (ModelState.IsValid)
            {
                assign.CreatedAt = DateTime.UtcNow;
               

                _db.Assigns.Add(assign);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }
  
    }
}
