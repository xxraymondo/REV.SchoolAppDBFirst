using System;
using System.Collections.Generic;

namespace SchoolAppDBFirst.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
