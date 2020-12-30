using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models
{
    public class Teacher
    {
        public Teacher()
        {
            //this.Students = new HashSet<Student>();
        }
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
