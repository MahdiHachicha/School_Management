using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public interface ICourseRepository
    {
        IList<Course> GetAll();
        Course GetById(int id);
        void Add(Course s);
        void Edit(Course s);
        void Delete(Course s);
        ICollection<Course> GetCourseByTeacherId(int? courseId);

    }
}
