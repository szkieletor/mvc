using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Classroom ClassRoom { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}