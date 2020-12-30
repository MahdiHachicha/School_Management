using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<StudentCourse>();
        }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> Students { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
