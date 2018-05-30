using School.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class TeacherToSubjectToStudent
    {
        [Key]
        public int TeacherToSubjectToStudentsID { get; set; }
        public int StudentAttendsSubjectID { get; set; }
        public virtual StudentToSubject StudentAttendsSubject { get; set; }
        public int TeacherTeachesSubjectID { get; set; }
        public virtual TeacherToSubject TeacherTeachesSubject { get; set; }
        public EMarkValues MarkValues { get; set; }
        public EMarkValues SemesterEndMark { get; set; }
        public EMarkValues FinalMark { get; set; }
        public ESemester Semester { get; set; }

    }
}