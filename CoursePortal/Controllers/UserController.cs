using System;
using System.Collections.Generic;
using CoursePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursePortal.Controllers
{
    public class UserController : Controller
    {

        //private SubscriberRepository subscriberRepository;
        //private AuthorRepository authorRepository;

        //public UserController(SubscriberRepository subscriberRepository,
        //    AuthorRepository authorRepository)
        //{
        //    this.authorRepository = authorRepository;
        //    this.subscriberRepository = subscriberRepository;
        //}

        //// GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Employee/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Employee/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employee/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }

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
