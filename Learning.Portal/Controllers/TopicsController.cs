using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Learning.Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class TopicsController : BaseController
    {
        private readonly LearningDbContext _db = null;
        public TopicsController(LearningDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Topics.Include(x=> x.Questions).ToList());
        }

        public ActionResult Create()
        {
            ViewData["Classes"] = _db.GetClasses();
            ViewData["Subjects"] = _db.GetSubjects();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TopicVM topicVM)
        {
            if (ModelState.IsValid)
            {
                var topic = new Topic()
                {
                    IsActive = true,
                    CreatedBy = CurrentUser(_db),
                    CreatedAt = DateTime.UtcNow,
                    Description = topicVM.Description,
                    Name = topicVM.Name,
                    Class = _db.Classes.Find(topicVM.Class),
                    Subject = _db.Subjects.Find(topicVM.Subject)
                };
                
                _db.Topics.Add(topic);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }
        public ActionResult Details(int id)
        {
            var topic = _db.Topics.FirstOrDefault(x => x.Id == id);
            return View(new TopicVM()
            {
                Name = topic.Name,
                Description = topic.Description,
                CreatedAt = topic.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                QuestionsCount = topic.Questions.Count
            });
        }

        public ActionResult Edit(int id)
        {
            var topic = _db.Topics.Include(c => c.Class).Include(c => c.Subject).FirstOrDefault(x => x.Id == id);
            if (topic == null)
            {
                ModelState.AddModelError("", "Topic not found");
                return RedirectToAction("Index");
            }

            ViewData["Classes"] = _db.GetClasses(topic.Class);
            ViewData["Subjects"] = _db.GetSubjects(topic.Subject);

            return View(new TopicVM()
            {
                Id = topic.Id,
                Description = topic.Description,
                Name = topic.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TopicVM topicVM)
        {
            if (ModelState.IsValid)
            {
                var existingTopic = _db.Topics.Find(topicVM.Id);

                if (existingTopic != null)
                {
                    existingTopic.Name = topicVM.Name;
                    existingTopic.Description = topicVM.Description;
                    existingTopic.Class = _db.Classes.Find(topicVM.Class);
                    existingTopic.Subject = _db.Subjects.Find(topicVM.Subject);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Topic not found!");
                    return View(topicVM);
                }
            }
            return RedirectToAction("DataError", "Error");
        }
    }
}