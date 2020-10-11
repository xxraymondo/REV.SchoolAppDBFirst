using System;
using System.Collections.Generic;

namespace SchoolAppDBFirst.Models
{
    public partial class School
    {
        public School()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
