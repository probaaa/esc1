using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School.Models.Enum;

namespace School.Models
{
    public class Grade
    {
        //this entity should be deleted. Using TeacherToSubjectToStudent now
        public int Id { get; set; }
        public EMarkValues GradeValues { get; set; }
        public EMarkValues SemesterEndGrade { get; set; }
        public EMarkValues FinalGrade { get; set; }
        public ESemester Semester { get; set; }
        public Grade()
        { }

    }
}