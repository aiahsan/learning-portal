using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Helper;
using Learning.Portal.Migrations;
using Learning.Portal.Models;
using Learning.Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    [Authorize]
    public class TestsController : BaseController
    {
        private readonly LearningDbContext _db = null;
        public TestsController(LearningDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
        public IActionResult Index()
        {
            return View(TestsByRole(_db));
        }

        [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
        public IActionResult Create()
        {
            ViewData["Topics"] = _db.GetTopic();
            ViewData["Questions"] = QuestionssByRole(_db).Select(x => new QuestionVM { Id = x.Id, Q = x.Title, Topic = x.Topic.Id }).ToList();
            return View();
        }

        [Authorize(Roles = Role.Admin + "," + Role.Teacher)]
        [HttpPost]
        public IActionResult Create(string title, int topic, List<int> questions)
        {
            var test = new Test()
            {
                Title = title,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = CurrentUser(_db),
                Topic = _db.Topics.Find(topic),
                IsActive = true
            };

            foreach (var question in questions)
                test.TestQuestions.Add(new TestQuestion() { QuestionId = question });

            _db.Tests.Add(test);
            _db.SaveChanges();
            return View();
        }

        [HttpPost]
        public string SubmitAnswers(int Id, List<AnswerVM> answers)
        {
            var test = _db.Tests.Include(x => x.TestQuestions).ThenInclude(x => x.Question).FirstOrDefault(c => c.Id == Id);
            var totalQuestions = test.TestQuestions.Count;
            var correctAnswers = test.TestQuestions.Count(x => answers.Any(c => c.Question == x.Question.Id && c.Answer == x.Question.CorrectAnswer));
            return $"You have {correctAnswers} correct answer our of {totalQuestions}. Your percentage is : {Math.Round(((double)correctAnswers / (double)totalQuestions) * 100, 2)} %!";
        }

        
        public ActionResult Details(int id)
        {
            var test = TestByRole(id, _db);
            if (test == null)
            {
                ModelState.AddModelError("", "Test not found");
                return RedirectToAction("Index");
            }
            return View(new TestVM()
            {
                Title = test.Title,
                ClassName = test.Topic.Class.Title,
                CreatedAt = test.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                Questions = test.TestQuestions.Select(x => new QuestionVM()
                {
                    Q = x.Question.Q,
                    Id = x.Question.Id,
                    IsMcq = x.Question.IsMcq,
                    IsPublic = x.Question.IsPublic,
                    CorrectAnswer = x.Question.CorrectAnswer,

                    Topic = x.Question.Topic.Id,
                    TopicName = x.Question.Topic.Name,

                    Subject = x.Question.Topic.Subject.Id,
                    SubjectName = x.Question.Topic.Subject.Title,

                    Class = x.Question.Topic.Class.Id,
                    ClassName = x.Question.Topic.Class.Title
                }).ToList(),
                SubjectName = test.Topic.Subject.Title,
                Id = test.Id
            });
        }

        public ActionResult DeleteQuestion(int id, int testId)
        {
            var question = _db.Questions.FirstOrDefault(c => c.Id == id);
            if (question != null)
            {
                _db.Questions.Remove(question);
                _db.SaveChanges();
            }
            return RedirectToAction("ViewTest", new { id = testId });
        }
        public ActionResult ViewTest(int id)
        {
            var test = TestByRole(id, _db);
            if (test == null)
            {
                ModelState.AddModelError("", "Test not found");
                return RedirectToAction("Index");
            }
            return View(new TestVM()
            {
                Title = test.Title,
                ClassName = test.Topic.Class.Title,
                CreatedAt = test.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                Questions = test.TestQuestions.Select(x => new QuestionVM()
                {
                    Q = x.Question.Q,
                    Id = x.Question.Id,
                    IsMcq = x.Question.IsMcq,
                    IsPublic = x.Question.IsPublic,
                    CorrectAnswer = x.Question.CorrectAnswer,

                    Topic = x.Question.Topic.Id,
                    TopicName = x.Question.Topic.Name,

                    Subject = x.Question.Topic.Subject.Id,
                    SubjectName = x.Question.Topic.Subject.Title,

                    Class = x.Question.Topic.Class.Id,
                    ClassName = x.Question.Topic.Class.Title
                }).ToList(),
                SubjectName = test.Topic.Subject.Title,
                Id = test.Id
            });
        }

        public ActionResult AssignTest()
        {
            var students=_db.Assigns.Where(x => x.User1.UserName == User.Identity.Name).Select(x => x.User).ToList();
            var test=_db.Tests;
            ViewBag.students = students;
            ViewBag.test= test; 
            return View();
        }

        [HttpPost]
        public ActionResult AssignTest(parrentTest parrent)
        {
            var students = _db.Assigns.Where(x => x.User1.UserName == User.Identity.Name).Select(x => x.User).ToList();
            
            return View();
        }

        public ActionResult studentTest()
        {
            if (User.Identity != null)
            {
                 
            }
            return View();
        }
    }
}