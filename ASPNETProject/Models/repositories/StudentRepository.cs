using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly SchoolDbContext context;
        public StudentRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Add(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
        }

        public void Delete(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if (s1 != null)
            {
                context.Students.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(Student newstudent)
        {
            Student oldstudent = context.Students.Find(newstudent.StudentId);
            if (oldstudent != null)
            {
                oldstudent.FirstName = newstudent.FirstName;
                oldstudent.LastName = newstudent.LastName;
                oldstudent.BirthDate = newstudent.BirthDate;
                context.SaveChanges();
            }
        }

        public IList<Student> GetAll()
        {
            return context.Students.OrderBy(x => x.StudentId).Include(x => x.Courses).ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Where(x => x.StudentId == id).Include(x => x.Courses).SingleOrDefault();
        }

        public IList<Student> FindByName(string name)
        {
            return context.Students.Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name)).Include(std => std.Courses).ToList();

        }

        public IList<Student> GetStudentsByCourseID(int? courseId)
        {
            IList< Student > students= new List<Student>();
            IList< StudentCourse> course = context.StudentCourse.Where(s => s.CourseId.Equals(courseId)).ToList();
            foreach(StudentCourse sc in course ){
                students.Add(context.Students.Find(sc.StudentId));
            }

            return students;
           

        }

        public IList<Course> GetStudentCourses(int id)
        {
            Student student = GetById(id);
            IList<Course> courses = new List<Course>();

            foreach (StudentCourse sc in student.Courses) {
                courses.Add(context.Courses.Where(s => s.CourseId.Equals(sc.CourseId)).SingleOrDefault());
            }

            return courses;
        }
    }
}
