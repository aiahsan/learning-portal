using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.Portal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Portal.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Portal()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewData["user"] = HttpContext.User?.Identity?.Name ?? null;
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }
    }
}