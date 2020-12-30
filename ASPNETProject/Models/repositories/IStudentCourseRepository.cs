using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public interface IStudentCourseRepository
    {
        IList<StudentCourse> GetAll();
        StudentCourse GetById(int id);
        void Add(StudentCourse s);
        void Edit(StudentCourse s);
        void Delete(StudentCourse s);
    }
}
