using System;
using CoursePortal.Entities;
using CoursePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePortal.Repository;

namespace CoursePortal.Controllers
{
    public class UserController : Controller
    {

        private SubscriberRepository subscriberRepository;
        private AuthorRepository authorRepository;

        public UserController(SubscriberRepository subscriberRepository,
            AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
            this.subscriberRepository = subscriberRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                string login = user.Login;
                string password = user.Password;

                Author author = authorRepository.FindByLogin(login);
                if (author != null)
                {
                    if (author.Password == password)
                    {
                        HttpContext.Session.Set("userId", BitConverter.GetBytes(author.Id));
                        HttpContext.Session.Set("isAuth", BitConverter.GetBytes(true));
                        ViewBag.HasErrors = false;
                        return RedirectToAction("AuthorIndex", "Course");
                    }
                }
                Subscriber subscriber = subscriberRepository.FindByLogin(login);
                if (subscriber != null)
                {
                    if (subscriber.Password == password)
                    {
                        HttpContext.Session.Set("userId", BitConverter.GetBytes(subscriber.Id));
                        HttpContext.Session.Set("isAuth", BitConverter.GetBytes(false));
                        ViewBag.HasErrors = false;
                        return RedirectToAction("SubscriberIndex", "Course");
                    }
                }
                ViewBag.HasErrors = true;
                ViewBag.LoginError = "Login or password is incorrect";

                return View(user);
            }
            catch
            {
                ViewBag.HasErrors = true;
                ViewBag.LoginError = "Something went wrong. Please contact your system administrator";
                return View(user);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            try
            {
                if (user.isAuthor)
                {
                    Author author = new Author();
                    author.Name = user.Name;
                    author.Login = user.Login;
                    author.Password = user.Password;
                    authorRepository.Create(author);
                }
                else
                {
                    Subscriber subscriber = new Subscriber();
                    subscriber.Name = user.Name;
                    subscriber.Login = user.Login;
                    subscriber.Password = user.Password;
                    subscriberRepository.Create(subscriber);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(user);
            }
        }
    }
}
