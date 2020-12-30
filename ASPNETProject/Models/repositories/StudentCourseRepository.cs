using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        readonly SchoolDbContext context;
        public StudentCourseRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Add(StudentCourse s)
        {
            context.StudentCourse.Add(s);
            context.SaveChanges();
        }

        public void Delete(StudentCourse s)
        {
            StudentCourse s1 = context.StudentCourse.Find(s.StudentId);
            if (s1 != null)
            {
                context.StudentCourse.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(StudentCourse newStudentCourse)
        {
            StudentCourse oldStudentCourse = context.StudentCourse.Find(newStudentCourse.StudentCourseId);
            if (oldStudentCourse != null)
            {
                oldStudentCourse.CourseId = newStudentCourse.CourseId;
                oldStudentCourse.StudentId = newStudentCourse.StudentId;
                context.SaveChanges();
            }
        }

        public IList<StudentCourse> GetAll()
        {
            return context.StudentCourse.OrderBy(x => x.StudentId).ToList();
        }

        public StudentCourse GetById(int id)
        {
            return context.StudentCourse.Where(x => x.StudentCourseId == id).SingleOrDefault();
        }
    }
}
