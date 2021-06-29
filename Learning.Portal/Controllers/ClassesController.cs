using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Learning.Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class ClassesController : Controller
    {
        private readonly LearningDbContext _db = null;
        public ClassesController(LearningDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Classes.Include(c=> c.Topics).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClassVM classVM)
        {
            if (ModelState.IsValid)
            {
                var _class = new Class()
                {
                    Description = classVM.Description,
                    CreatedAt = DateTime.UtcNow,
                    Title = classVM.Title
                };

                _db.Classes.Add(_class);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }
        public ActionResult Details(int id)
        {
            var _class = _db.Classes.FirstOrDefault(x=> x.Id == id);
            return View(new ClassVM()
            {
                Title = _class.Title,
                Description = _class.Description,
                CreatedAt = _class.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                TopicsCount = _class.Topics.Count
            });
        }

        public ActionResult Edit(int id)
        {
            var _class = _db.Classes.Find(id);
            if (_class == null)
            {
                ModelState.AddModelError("", "Class not found");
                return RedirectToAction("Index");
            }
            return View(new ClassVM()
            {
                Id = _class.Id,
                Description = _class.Description,
                Title = _class.Title
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(ClassVM classVM)
        {
            if (ModelState.IsValid)
            {
                var existingClass = _db.Classes.Find(classVM.Id);

                if (existingClass != null)
                {
                    existingClass.Title = classVM.Title;
                    existingClass.Description = classVM.Description;

                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Class not found!");
                    return View(classVM);
                }
            }
            return RedirectToAction("DataError", "Error");
        }

    }
}