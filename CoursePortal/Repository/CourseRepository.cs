using System;
using CoursePortal.Context;
using CoursePortal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoursePortal.Repository
{
    public class CourseRepository 
    {
        private readonly CourseContext _courseContext;

        public CourseRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public Course Create(Course course)
        {
            Course createdCourse = _courseContext.Courses.Add(course);
            _courseContext.SaveChanges();

            return createdCourse;
        }

        public Course Read(int id)
        {
            return _courseContext.Courses
                .Include(course => course.Author)
                .Include(course => course.Subscriptions)
                .Include(course => course.Subject)
                .ToList()
                .Find(rec => rec.Id == id);
        }

        public List<Course> ReadAll()
        {
            return _courseContext.Courses
                .Include(course => course.Author)
                .Include(course => course.Subscriptions)
                .Include(course => course.Subject)
                .ToList();
        }

        public Course Update(Course course)
        {
            Course courseToUpdate = Read(course.Id);
            UpdateCourse(courseToUpdate, course);
            _courseContext.SaveChanges();

            return courseToUpdate;
        }

        public Course Delete(Course course)
        {
            _courseContext.Courses.Remove(course);
            _courseContext.SaveChanges();

            return course;
        }

        public List<Course> FullTextSearch(string name, String desc)
        {
            string query = string.Format("Select * From Courses Where Name LIKE '%{0}%' OR Description LIKE '%{1}%'", name, desc);
            List<Course> courses = _courseContext.Database.SqlQuery<Course>(query).ToList();

            return courses;
        }

        private void UpdateCourse(Course courseToUpdate, Course course)
        { 
            courseToUpdate.Id = course.Id;
            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;
        }
    }
}
