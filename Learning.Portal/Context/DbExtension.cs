using Learning.Portal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Context
{
    public static class DbExtension
    {
        public static List<SelectListItem> GetTopic(this LearningDbContext _db)
        {
            return _db.Topics.Include(x => x.Class)
                             .Include(x => x.Subject)
                             .Select(x => new SelectListItem
                             {
                                 Text = $"{x.Class.Title}-{x.Subject.Title}-{x.Name}",
                                 Value = x.Id.ToString()
                             }).ToList();
        }
        public static List<SelectListItem> GetClasses(this LearningDbContext _db)
        {
            return _db.Classes.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
        }
        public static List<SelectListItem> GetSubjects(this LearningDbContext _db)
        {
            return _db.Subjects.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
        }
        public static List<Question> GetQuestions(this LearningDbContext _db, Topic _topic)
        {
            return _db.Questions.Include(c=> c.Topic).ToList();
        }
        public static List<SelectListItem> GetClasses(this LearningDbContext _db, Class _class)
        {
            return _db.Classes.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString(), Selected = _class != null && x.Id == _class.Id }).ToList();
        }
        public static List<SelectListItem> GetSubjects(this LearningDbContext _db, Subject _subject)
        {
            return _db.Subjects.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString(), Selected = _subject != null && x.Id == _subject.Id }).ToList();
        }
    }
}
