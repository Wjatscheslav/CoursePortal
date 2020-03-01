using System;
using CoursePortal.Entities;
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
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                string login = collection["Login"];
                string password = collection["Password"];

                Author author = authorRepository.FindByLogin(login);
                if (author != null)
                {
                    if (author.Password == password)
                    {
                        HttpContext.Session.Set("userId", BitConverter.GetBytes(author.Id));
                        HttpContext.Session.Set("isAuth", BitConverter.GetBytes(true));
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
                        return RedirectToAction("SubscriberIndex", "Course");
                    }
                }
                return View();
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
                bool isAuth = Convert.ToBoolean(collection["isAuthor"].ToString().Split(',')[0]);
                if (isAuth)
                {
                    Author author = new Author();
                    author.Name = collection["Name"];
                    author.Login = collection["Login"];
                    author.Password = collection["Password"];
                    authorRepository.Create(author);
                }
                else
                {
                    Subscriber subscriber = new Subscriber();
                    subscriber.Name = collection["Name"];
                    subscriber.Login = collection["Login"];
                    subscriber.Password = collection["Password"];
                    subscriberRepository.Create(subscriber);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
