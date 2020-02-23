using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoursePortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
    }
}
