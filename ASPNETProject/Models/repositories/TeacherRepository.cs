using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        readonly SchoolDbContext context;
        public TeacherRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Add(Teacher s)
        {
            context.Teachers.Add(s);
            context.SaveChanges();
        }

        public void Delete(Teacher s)
        {
            Teacher teacher = context.Teachers.Find(s.TeacherId);
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
        }

        public void Edit(Teacher newteacher)
        {
            Teacher oldTeacher = context.Teachers.Find(newteacher.TeacherId);
            if (oldTeacher != null)
            {
                oldTeacher.FirstName = newteacher.FirstName;
                oldTeacher.LastName = newteacher.LastName;
                oldTeacher.PhoneNumber = newteacher.PhoneNumber;
                context.SaveChanges();
            }
        }

        public IList<Teacher> GetAll()
        {
            return context.Teachers.OrderBy(x => x.TeacherId).Include(x => x.Courses).ToList();
        }

        public IList<TeacherSummary> GetAllSummary()
        {
            var TeachersList = GetAll();
            var newList = new List<TeacherSummary>();
            foreach (Teacher t in TeachersList)
            {
                TeacherSummary ts = new TeacherSummary();
                ts.TeacherId = t.TeacherId;
                ts.Name = t.FirstName + " " + t.LastName;
                newList.Add(ts);
            }
            return newList;
        }

        public Teacher GetById(int id)
        {
            return context.Teachers.Where(x => x.TeacherId == id).Include(x => x.Courses).SingleOrDefault();
        }
    }
}
