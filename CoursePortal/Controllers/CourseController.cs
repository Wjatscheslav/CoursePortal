using System;
using System.Collections.Generic;
using System.Linq;
using CoursePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePortal.Repository;


namespace CoursePortal.Controllers
{
    public class CourseController : Controller
    {

        private SubscriberRepository subscriberRepository;
        private AuthorRepository authorRepository;

        public CourseController(SubscriberRepository subscriberRepository,
            AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
            this.subscriberRepository = subscriberRepository;
        }
        public IActionResult SubscriberIndex()
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            Subscriber subscriber = subscriberRepository.FindById(userId);
           
            User user = new User();
            user.Name = subscriber.Name;
            return View(user);
        }

        public IActionResult AuthorIndex()
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            Author author = authorRepository.FindById(userId);

            User user = new User();
            user.Name = author.Name;
            return View(user);
        }

        public IActionResult Courses()
        {
            UserCourses userCourses = prepareUserCourses();

            // add logic for filling course model

            return View(userCourses);
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(IFormCollection collection)
        {
            // Add logic to save course into the db
            return RedirectToAction("Courses", "Course");
        }

        public IActionResult AvailableCourses()
        {
            // Add logic to get available courses from db
            return View(prepareUserCourses());
        }

        public IActionResult Subscribe(int id)
        {
            // Add logic to save subscription and return updated collection
            return RedirectToAction("Courses", "Course");
        }

        public IActionResult Unsubscribe(int id)
        {
            // Add logic to remove subscription and return updated collection
            UserCourses userCourses = prepareUserCourses();
            userCourses.courses = userCourses.courses
                .Where(course => course.Id != id)
                .ToList();
            return RedirectToAction("Courses", "Course");
        }

        public IActionResult RemoveCourse(int id)
        {
            // Add logic to remove course and all related subscriptions
            UserCourses userCourses = prepareUserCourses();
 
            return RedirectToAction("Courses", "Course");
        }

        private UserCourses prepareUserCourses()
        {
            UserCourses userCourses = new UserCourses();
            User user = new User();
            user.Name = "SuperUser";
            userCourses.user = user;
            userCourses.courses = new List<CourseModel>{
                new CourseModel {
                    Id = 1,
                    Name = "C# for dummies",
                    Description = "Jopa",
                    AuthorName = "Slavka",
                    SubjectName = "Programming"
                },
                new CourseModel {
                    Id = 2,
                    Name = "One more course",
                    Description = "Jopa Jopa",
                    AuthorName = "Slavka",
                    SubjectName = "Programming"
                }
            };
            return userCourses;
        }
    }
}
