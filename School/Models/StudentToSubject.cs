using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class StudentToSubject
    {
        [Key]
        public int StudentAttendsSubjectID { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual TeacherToSubjectToStudent TeacherToSubjectToStudent { get; set; }

        public StudentToSubject()
        { }
    }
}