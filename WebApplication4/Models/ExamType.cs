using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ExamType
    {
        [Required]
        public int ExamTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}