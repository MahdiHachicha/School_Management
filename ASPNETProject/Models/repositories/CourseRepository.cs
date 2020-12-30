using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public class CourseRepository : ICourseRepository
    {
        readonly SchoolDbContext context;
        public CourseRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Add(Course s)
        {
            context.Courses.Add(s);
            context.SaveChanges();
        }

        public void Delete(Course s)
        {
            Course course1 = context.Courses.Find(s.CourseId);
            if (course1 != null)
            {
                context.Courses.Remove(course1);
                context.SaveChanges();
            }
        }

        public void Edit(Course newCourse)
        {
            Course oldCourse = context.Courses.Find(newCourse.CourseId);
            if (oldCourse != null)
            {
                oldCourse.CourseName = newCourse.CourseName;
                context.SaveChanges();
            }
        }

        public IList<Course> GetAll()
        {
            return context.Courses.OrderBy(x => x.CourseId).Include(x => x.Teacher).ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Where(x => x.CourseId == id).Include(x =>x.Teacher).SingleOrDefault();

        }

        public ICollection<Course> GetCourseByTeacherId(int? techerid)
        {
            return context.Courses.Where(s => s.TeacherId.Equals(techerid))
                .OrderBy(s => s.CourseId)
                .Include(course => course.Teacher).ToList();
        }
    }
}
