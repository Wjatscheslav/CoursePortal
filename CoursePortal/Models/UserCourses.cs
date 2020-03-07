using System;
using System.Collections.Generic;

namespace CoursePortal.Models
{
    public class UserCourses
    {
        public User user { get; set; }
        public List<CourseModel> courses { get; set; }
        public string filterBy { get; set; }
    }
}
