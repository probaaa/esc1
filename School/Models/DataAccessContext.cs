using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace School.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("ESchoolConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentToSubject> StudentAttendsSubjects { get; set; }
        public DbSet<TeacherToSubject> TeacherTeachesSubjects { get; set; }
        public DbSet<TeacherToSubjectToStudent> TeacherToSubjectToStudents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        // public DbSet<Grade> Grades { get; set; }        
    }
}