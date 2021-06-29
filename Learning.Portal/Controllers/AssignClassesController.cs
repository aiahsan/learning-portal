using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    public class AssignClassesController : BaseController
    {
        private readonly LearningDbContext _db = null;
        private readonly UserManager<User> _userManager;
        public AssignClassesController(UserManager<User> userManager, LearningDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.AssignClasses.Include(x=>x.User).Include(x=>x.Class).ToList());

        }


        public ActionResult Create()
        {

            ViewBag.users = UsersByRole(_db);
            ViewBag.Classes = _db.Classes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AssignClass assign)
        {
            ViewBag.users = UsersByRole(_db);
            ViewBag.Classes = _db.Classes.ToList();

            if (ModelState.IsValid)
            {
                assign.CreatedAt = DateTime.UtcNow;
                assign.IsActive = true;

                _db.AssignClasses.Add(assign);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }



    }
}
