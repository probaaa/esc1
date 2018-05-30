using School.Models;
using School.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Services
{
    public class TeachersService : ITeachersService
    {
        private IUnitOfWork db;

        public TeachersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.TeacherRepository.Get(); 
        }

        public Teacher GetById(int id)
        {
            return db.TeacherRepository.GetByID(id);
        }

        public Teacher InsertTeacher(Teacher newTeacher)
        {
            db.TeacherRepository.Insert(newTeacher);
            db.Save();
            return newTeacher;
        }

        public Teacher UpdateTeacher(int id, Teacher updatedTeacher)
        {
            Teacher teacher = db.TeacherRepository.GetByID(id);

            if (teacher != null)
            {
                teacher.FirstName = updatedTeacher.FirstName;
                teacher.LastName = updatedTeacher.LastName;
                teacher.Username = updatedTeacher.Username;
                teacher.Email = updatedTeacher.Email;

                db.TeacherRepository.Update(teacher);
                db.Save();
            }

            return teacher;
        }
        public Teacher DeleteTeacher(int id)
        {
            Teacher teacher = db.TeacherRepository.GetByID(id);
            if (teacher == null)
            {
                return null;
            }
            db.TeacherRepository.Delete(teacher);
            db.Save();

            return teacher;
        }
    }
}