using System;
using Microsoft.AspNetCore.Mvc;

namespace CoursePortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
