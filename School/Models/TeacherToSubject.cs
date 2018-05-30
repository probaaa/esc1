using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class TeacherToSubject
    {
        [Key]
        public int TeacherTeachesSubjectID { get; set; }
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<TeacherToSubjectToStudent> TeacherToSubjectToStudents { get; set; }
    }
}