using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace School.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        [Dependency]
        public IGenericRepository<Parent> ParentRepository { get; set; }
        [Dependency]
        public IGenericRepository<Teacher> TeacherRepository { get; set; }
        [Dependency]
        public IGenericRepository<Student> StudentRepository { get; set; }
        [Dependency]
        public IGenericRepository<User> UserRepository { get; set; }
        [Dependency]
        public IGenericRepository<Grade> GradeRepository { get; set; }
        [Dependency]
        public IGenericRepository<Subject> SubjectRepository { get; set; }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}