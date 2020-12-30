using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Models.repositories
{
    public interface ITeacherRepository
    {
        IList<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(Teacher s);
        void Edit(Teacher s);
        void Delete(Teacher s);

        IList<TeacherSummary> GetAllSummary();

    }
}
