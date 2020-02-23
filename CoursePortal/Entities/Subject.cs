﻿using System;
using System.Collections.Generic;

namespace CoursePortal.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Course> Courses { get; set; }
    }
}
