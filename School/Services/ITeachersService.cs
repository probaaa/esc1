using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Services
{
    public interface ITeachersService
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetById(int id);
        Teacher InsertTeacher(Teacher newTeacher);
        Teacher UpdateTeacher(int id, Teacher updatedTeacher);
        Teacher DeleteTeacher(int id);
    }
}