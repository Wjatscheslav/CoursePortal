using System;
using System.Collections.Generic;
using CoursePortal.Context;
using CoursePortal.Models;
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
        public Author FindById(int id)
        {
            return _courseContext.Authors.Where(auth => auth.Id == id).SingleOrDefault();
        }

        public Author FindByLogin(string login)
        {
            return _courseContext.Authors.Where(auth => auth.Login == login).SingleOrDefault();
        }

    }
}
