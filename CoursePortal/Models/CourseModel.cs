using System;
using System.ComponentModel.DataAnnotations;

namespace CoursePortal.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string AuthorName { get; set; }
        [Required] 
        public string SubjectName { get; set; }
    }
}
