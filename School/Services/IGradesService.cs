using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public interface IGradesService
    {
        IEnumerable<Grade> GetAllGrades();
        Grade GetById(int id);
        Grade InsertGrade(Grade newGrade);
        Grade UpdateGrade(int id, Grade updatedGrade);
        Grade DeleteGrade(int id);

    }
}
