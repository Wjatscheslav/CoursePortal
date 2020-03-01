using System;
using System.ComponentModel.DataAnnotations;

namespace CoursePortal.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string Login { get; set; }
        [Required]
        [MinLength(7)]
        public string Password { get; set; }
        public bool isAuthor { get; set; }
    }
}
