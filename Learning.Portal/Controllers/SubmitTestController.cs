using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Context;
using Learning.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Portal.Controllers
{
    public class SubmitTestController : BaseController
    {
        private readonly LearningDbContext _db = null;
        public SubmitTestController(LearningDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           
            return View(GetTests(_db));
        }
        public IActionResult Submit(int? id)
        {
            if (id != null)
            {
                var obj = GetTests(_db).FirstOrDefault(x => x.Id == id.Value);
                if (obj != null)
                {
                    return View(obj);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit()
        {
            
            return RedirectToAction("index");
        }
    }
}
