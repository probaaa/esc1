using School.Models;
using School.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Services
{
    public class StudentsService : IStudentsService
    {
        private IUnitOfWork db;

        public StudentsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.StudentRepository.Get();
        }

        public Student GetById(int id)
        {
            return db.StudentRepository.GetByID(id);
        }

        public Student InsertStudent(Student newStudent)
        {           
            db.StudentRepository.Insert(newStudent);
            db.Save();
            return newStudent;
        }

        public Student UpdateStudent(int id, Student updatedStudent)
        {
            Student student = db.StudentRepository.GetByID(id);

            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Username = updatedStudent.Username;
                student.Email = updatedStudent.Email;

                db.StudentRepository.Update(student);
                db.Save();
            }

            return student;
        }
        public Student DeleteStudent(int id)
        {
            Student student = db.StudentRepository.GetByID(id);
            if (student == null)
            {
                return null;
            }
            db.StudentRepository.Delete(student);
            db.Save();

            return student;
        }
    }
}