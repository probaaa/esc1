using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School.Models.Enum;

namespace School.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int WeeklyFund { get; set; }
        public ESemester Semester { get; set; }
        public List<EGradeYear> Grades { get; set; }
        public virtual ICollection<StudentToSubject> StudentAttendsSubjects { get; set; }
        public virtual ICollection<TeacherToSubject> TeacherTeachesSubjects { get; set; }
       
        public Subject()
        { }

    }
}