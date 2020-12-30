using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Edit(Student s);
        void Delete(Student s);
        IList<Student> GetStudentsByCourseID(int? courseId);
        IList<Student> FindByName(string name);
        IList<Course> GetStudentCourses(int id);

    }
}
