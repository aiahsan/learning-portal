using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser(LearningDbContext db)
        {
            return db.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
        }
        public List<User> UsersByRole(LearningDbContext db)
        {
            var users = db.Users.AsEnumerable();

            if (User.IsInRole(Role.Teacher) || User.IsInRole(Role.Parent))
                users = users.Where(x => x.CreatedBy != null && x.CreatedBy.UserName == User.Identity.Name);

            return users.ToList();
        }
        
        public User UserByRole(int id, LearningDbContext db)
        {
            Expression<Func<User, bool>> expression;

            if (User.IsInRole(Role.Teacher) || User.IsInRole(Role.Parent))
                expression = c => c.Id == id && c.CreatedBy != null && c.CreatedBy.UserName == User.Identity.Name;
            else
                expression = c => c.Id == id;

            return db.Users.FirstOrDefault(expression);
        }


        public IEnumerable<Test> GetTests(LearningDbContext _db)
        {
            if (User.Identity != null)
            {
                var user = _db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                if (user != null)
                {
                    var Class = _db.AssignClasses.Include(x => x.User).Include(x => x.Class).Where(x => x.User.Id == user.Id).FirstOrDefault();

                    if (Class != null)
                    {
                        if (Class.Class != null)
                        {
                          var test = _db.Tests.Include(x => x.Topic).ThenInclude(x => x.Class).Where(x => x.Topic.Class.Id == Class.Class.Id);
                          return  test.Include(x => x.TestQuestions).ThenInclude(x=>x.Question).ToList();

                        }
                    }

                }

            }
            return new List<Test>();
        }
        public List<string> GetRoles()
        {
            if (User.IsInRole(Role.Admin))
                return new List<string>() { Role.Admin, Role.Parent, Role.Teacher, Role.Student };
            else if (User.IsInRole(Role.Teacher))
                return new List<string>() { Role.Parent, Role.Student };
            else if (User.IsInRole(Role.Parent))
                return new List<string>() { Role.Teacher, Role.Student };
            else
                return null;
        }

        public List<Question> QuestionssByRole(LearningDbContext db)
        {
            var questions = db.Questions
                          .Include(c => c.CreatedBy)
                          .Include(x => x.Topic)
                          .Include(x => x.Topic.Class)
                          .Include(x => x.Topic.Subject)
                          .Include(x=> x.TestQuestions)
                          .AsEnumerable();

            if (User.IsInRole(Role.Teacher))
                questions = questions.Where(x => x.IsActive && (x.CreatedBy.UserName == User.Identity.Name || x.IsPublic));

            return questions.ToList();
        }

        public List<Test> TestsByRole(LearningDbContext db)
        {
            var tests = db.Tests
                          .Include(x => x.CreatedBy)
                          .Include(c => c.TestQuestions)
                          .Include(c => c.Topic)
                          .Include(c => c.Topic.Class)
                          .Include(c => c.Topic.Subject)
                          .AsEnumerable();

            if (User.IsInRole(Role.Teacher))
                tests = tests.Where(x => x.CreatedBy.UserName == User.Identity.Name);

            return tests.ToList();
        }

        public Test TestByRole(int id, LearningDbContext db)
        {
            Expression<Func<Test, bool>> expression = null;

            if (User.IsInRole(Role.Teacher))
                expression = c => c.Id == id && c.CreatedBy != null && c.CreatedBy.UserName == User.Identity.Name;
            else if (User.IsInRole(Role.Admin))
                expression = c => c.Id == id;

            return db.Tests.Include(x => x.TestQuestions)
                           .ThenInclude(x => x.Question)
                           .Include(c => c.Topic)
                           .Include(c => c.Topic.Class)
                           .Include(c => c.Topic.Subject).FirstOrDefault(expression);
        }
    }
}