using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Student : User
    {       
        [JsonIgnore]
        public virtual ICollection<StudentToSubject> StudentAttendsSubject { get; set; }
        [JsonIgnore]
        public virtual ICollection<Parent> Parents { get; set; }
        public Student()
        { }
    }
}