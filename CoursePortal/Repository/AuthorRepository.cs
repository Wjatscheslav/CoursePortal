using System;
using CoursePortal.Context;
using CoursePortal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoursePortal.Repository
{
    public class AuthorRepository
    {
        private readonly CourseContext _courseContext;

        public AuthorRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public Author Create(Author author)
        {
            Author createdAuthor = _courseContext.Authors.Add(author);
            _courseContext.SaveChanges();
            return createdAuthor;
        }
        public Author Read(int id)
        {
            return _courseContext.Authors
                .Include(auth => auth.Courses)
                .ToList()
                .Find(auth => auth.Id == id);
        }

        public Author FindByLogin(string login)
        {
            return _courseContext.Authors
                .Include(auth => auth.Courses)
                .ToList()
                .Find(auth => auth.Login == login);
        }

    }
}
