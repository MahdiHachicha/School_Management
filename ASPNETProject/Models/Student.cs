using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
       
        public DateTime BirthDate { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }
    }
}
