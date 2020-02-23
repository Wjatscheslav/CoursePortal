using System;
using CoursePortal.Context;
using CoursePortal.Models;

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
    }
}
