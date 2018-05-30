using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Parent> ParentRepository { get; }
        IGenericRepository<Teacher> TeacherRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<Grade> GradeRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<User> UserRepository { get; }

        void Save();
    }
}