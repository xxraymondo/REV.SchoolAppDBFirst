using System;
using System.Collections.Generic;

namespace SchoolAppDBFirst.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CourseLv { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
