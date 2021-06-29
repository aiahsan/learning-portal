using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Helper;
using Learning.Portal.Models;
using Learning.Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Learning.Portal.Controllers
{
   // [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
    public class QuestionsController : BaseController
    {
        private readonly LearningDbContext _db = null;
        public QuestionsController(LearningDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewData["Topics"] = _db.GetTopic();
            return View(QuestionssByRole(_db));
        }

      //  [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
        public ActionResult Create()
        {
            ViewData["Topics"] = _db.GetTopic();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
        public async Task<ActionResult> CreateCsv(IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
                var questions = formFile.OpenReadStream().Parse();

                foreach (var question in questions)
                    _db.Questions.Add(new Question()
                    {
                        CorrectAnswer = question.CorrectAnswer,
                        IsMcq = question.IsMcq,
                        IsPublic = question.IsPublic,
                        Topic = await _db.Topics.FindAsync(question.Topic),
                        Q = question.Q,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true,
                        CreatedBy = user
                    });

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = Role.Admin + "," + Role.Teacher)]
        public async Task<ActionResult> Create(QuestionVM questionVM)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
              
                    // Object jUser = jObject["user"];

                    _db.Questions.Add(new Question()
                {
                    CorrectAnswer = questionVM.CorrectAnswer,
                    IsMcq = questionVM.IsMcq,
                    IsPublic = questionVM.IsPublic,
                    Topic = await _db.Topics.FindAsync(questionVM.Topic),
                    Q = "<div class=\"col-lg-12\"><div class=\"form-group\">" + questionVM.Q + "</div></div>",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = user,
                    IsActive = true,
                    Title=questionVM.Title,
                });
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("DataError", "Error");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if(id!=null)
            {
              var question=  QuestionssByRole(_db).FirstOrDefault(x => x.Id == id.Value);
            if(question!=null)
                {
                    return View(question);
                }
            }
            return RedirectToAction("index");
        }
    }
}