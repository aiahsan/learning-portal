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
    public class SubjectsController : Controller
    {
        private readonly LearningDbContext _db = null;
        public SubjectsController(LearningDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Subjects.Include(c => c.Topics).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubjectVM subjectVM)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject()
                {
                    Description = subjectVM.Description,
                    CreatedAt = DateTime.UtcNow,
                    Title = subjectVM.Title
                };

                _db.Subjects.Add(subject);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }
        public ActionResult Details(int id)
        {
            var subject = _db.Subjects.FirstOrDefault(x => x.Id == id);
            return View(new SubjectVM()
            {
                Title = subject.Title,
                Description = subject.Description,
                CreatedAt = subject.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                TopicsCount = subject.Topics.Count
            });
        }

        public ActionResult Edit(int id)
        {
            var subject = _db.Subjects.Find(id);
            if (subject == null)
            {
                ModelState.AddModelError("", "Subject not found");
                return RedirectToAction("Index");
            }
            return View(new SubjectVM()
            {
                Id = subject.Id,
                Description = subject.Description,
                Title = subject.Title
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(SubjectVM subjectVM)
        {
            if (ModelState.IsValid)
            {
                var existingSubject = _db.Subjects.Find(subjectVM.Id);

                if (existingSubject != null)
                {
                    existingSubject.Title = subjectVM.Title;
                    existingSubject.Description = subjectVM.Description;

                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Subject not found!");
                    return View(subjectVM);
                }
            }
            return RedirectToAction("DataError", "Error");
        }
    }
}