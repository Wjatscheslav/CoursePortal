using System;
using CoursePortal.Context;
using CoursePortal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoursePortal.Repository
{
    public class SubjectRepository
    {

        private readonly CourseContext _courseContext;

        public SubjectRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public Subject Create(Subject subject)
        {
            Subject createdSubject = _courseContext.Subjects.Add(subject);
            _courseContext.SaveChanges();

            return createdSubject;
        }

        public Subject Read(int id)
        {
            return _courseContext.Subjects
                .Include(subj => subj.Courses)
                .ToList()
                .Find(rec => rec.Id == id);
        }

        public Subject FindByName(string name)
        {
            return _courseContext.Subjects
                .Include(subj => subj.Courses)
                .ToList()
                .Find(subj => subj.Name == name);
        }

        public List<Subject> ReadAll()
        {
            return _courseContext.Subjects
                .ToList();
        }
    }
}
