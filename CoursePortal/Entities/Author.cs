using System;
using System.Collections.Generic;

namespace CoursePortal.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Course> Courses { get; set; }
    }
}
