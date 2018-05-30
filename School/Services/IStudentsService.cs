using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetById(int id);
        Student InsertStudent(Student newStudent);
        Student UpdateStudent(int id, Student updatedStudent);
        Student DeleteStudent(int id);

    }
}
