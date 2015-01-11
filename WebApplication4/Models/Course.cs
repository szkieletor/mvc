using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ApplicationUser Teacher { get; set; }
    }
}