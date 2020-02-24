using System;
using System.Collections.Generic;
using CoursePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursePortal.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.Login = collection["Login"];
                user.Password = collection["Password"];

                // Temporary statement for testing
                if (user.Login == "author")
                {
                    user.isAuthor = true;
                }
                else
                {
                    user.isAuthor = false;
                }

                // Add logic for checking login information and authentication
                if (user.isAuthor)
                {
                    return RedirectToAction("AuthorIndex", "Course");
                }
                else
                {
                    return RedirectToAction("SubscriberIndex", "Course");
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.Name = collection["Name"];
                user.Login = collection["Login"];
                user.Password = collection["Password"];
                bool isAuth;
                bool.TryParse(collection["isAuthor"], out isAuth);
                user.isAuthor = isAuth;

                // Add saving user to DB

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }



        public List<User> GetEmployeeList()
        {
            return new List<User>{
      new User{
          Id = 1,
          Login = "L1",
          Password = "P1",
          Name = "Angelika"
      },

      new User{
          Id = 2,
          Login = "L2",
          Password = "P2",
          Name = "Leila"
      },
                new User{
          Id = 3,
          Login = "L3",
          Password = "P3",
          Name = "Zhanna"
      }

   };
        }

    }
}
