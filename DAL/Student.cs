using System;
using System.Collections.Generic;

namespace DAL
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
