﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoursePortal.Entities;
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
        private CourseRepository courseRepository;
        private SubscriptionRepository subscriptionRepository;
        private SubjectRepository subjectRepository;


        public CourseController(SubscriberRepository subscriberRepository,
            AuthorRepository authorRepository, CourseRepository courseRepository, 
            SubscriptionRepository subscriptionRepository, SubjectRepository subjectRepository)
        {
            this.authorRepository = authorRepository;
            this.subscriberRepository = subscriberRepository;
            this.courseRepository = courseRepository;
            this.subscriptionRepository = subscriptionRepository;
            this.subjectRepository = subjectRepository;
        }
        public IActionResult SubscriberIndex()
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            Subscriber subscriber = subscriberRepository.Read(userId);
           
            User user = new User();
            user.Name = subscriber.Name;
            return View(user);
        }

        public IActionResult AuthorIndex()
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            Author author = authorRepository.Read(userId);

            User user = new User();
            user.Name = author.Name;
            return View(user);
        }

        public IActionResult Courses()
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            User user = GetUserById(userId);
            List<CourseModel> courses;
            if (user.isAuthor)
            {
                courses = authorRepository.Read(userId).Courses
                    .ToList()
                    .Select(course => ToCourseModel(course))
                    .ToList();
            }
            else
            {
                courses = subscriptionRepository.FindByUserId(userId)
                    .ToList()
                    .Select(subs => courseRepository.Read(subs.CourseId))
                    .ToList()
                    .Select(course => ToCourseModel(course))
                    .ToList();
            }
            UserCourses userCourses = new UserCourses();
            userCourses.user = user;
            userCourses.courses = courses;

            return View(userCourses);
        }

        public IActionResult AddCourse()
        {
            List<string> subjects = subjectRepository.ReadAll()
                .Select(subj => subj.Name)
                .ToList();
            ViewBag.Subjects = subjects;
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(IFormCollection collection)
        {
            Subject subject = subjectRepository.FindByName(collection["SubjectName"]);
            Course course = new Course();
            course.Name = collection["Name"];
            course.Description = collection["Description"];
            course.AuthorId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            Author author = authorRepository.Read(course.AuthorId);
            course.SubjectId = subject.Id;
            course.Author = author;
            if (subject.Courses == null)
            {
                subject.Courses = new List<Course>();
            }
            subject.Courses.Add(course);
            if (author.Courses == null)
            {
                author.Courses = new List<Course>();
            }
            author.Courses.Add(course);
            courseRepository.Create(course);
            return RedirectToAction("Courses", "Course");
        }

        public IActionResult AvailableCourses()
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            List<int> addedCourseIds = subscriptionRepository.FindByUserId(userId)
                .Select(subs => subs.CourseId)
                .ToList();
            List<CourseModel> courses = courseRepository.ReadAll()
                .Where(course => !addedCourseIds.Contains(course.Id))
                .Select(course => ToCourseModel(course))
                .ToList();
            User user = GetUserById(userId);
            UserCourses userCourses = new UserCourses();
            userCourses.user = user;
            userCourses.courses = courses;
            return View(userCourses);
        }

        public IActionResult Subscribe(int id)
        {
            Subscription subscription = new Subscription();
            subscription.SubscriberId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            subscription.CourseId = id;
            subscriptionRepository.Create(subscription);
            return RedirectToAction("Courses", "Course");
        }

        public IActionResult Unsubscribe(int id)
        {
            int userId = BitConverter.ToInt32(HttpContext.Session.Get("userId"));
            Subscription subscription = subscriptionRepository.FindByUserId(userId)
                .Find(subs => subs.CourseId == id);
            subscriptionRepository.Delete(subscription);
            return RedirectToAction("Courses", "Course");
        }

        public IActionResult RemoveCourse(int id)
        {
            Course course = courseRepository.Read(id);
            courseRepository.Delete(course);
            return RedirectToAction("Courses", "Course");
        }

        private User GetUserById(int userId)
        {
            User user = new User();
            bool isAuth = BitConverter.ToBoolean(HttpContext.Session.Get("isAuth"));
            user.isAuthor = isAuth;
            if (isAuth)
            {
                Author author = authorRepository.Read(userId);
                user.Login = author.Login;
                user.Name = author.Name;
            }
            else
            {
                Subscriber subscriber = subscriberRepository.Read(userId);
                user.Login = subscriber.Login;
                user.Name = subscriber.Name;
            }

            return user;
        }

        private CourseModel ToCourseModel(Course course)
        {
            CourseModel courseModel = new CourseModel();
            courseModel.Id = course.Id;
            courseModel.Name = course.Name;
            courseModel.Description = course.Description;
            courseModel.AuthorName = course.Author.Name;
            courseModel.SubjectName = course.Subject.Name;

            return courseModel;
        }
    }
}
