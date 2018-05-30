using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Parent : User
    {
        public virtual ICollection<Student> Children { get; set; }
        public Parent()
        { }                              
    }
}