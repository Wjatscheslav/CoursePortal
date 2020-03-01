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

        private void UpdateCourse(Course courseToUpdate, Course course)
        { 
            courseToUpdate.Id = course.Id;
            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;
        }
    }
}
