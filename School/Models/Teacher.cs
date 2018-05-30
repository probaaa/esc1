using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Teacher : User
    {       
        public virtual ICollection<TeacherToSubject> TeacherTeachesSubject { get; set; }

        public Teacher()
        { }

    }

   

}