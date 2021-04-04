using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.Data
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}