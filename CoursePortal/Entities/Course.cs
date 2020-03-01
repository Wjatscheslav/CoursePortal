using System;
using System.Collections.Generic;

namespace CoursePortal.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
