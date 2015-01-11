using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ExamResult
    {
        [Required]
        public int ExamResultID { get; set; }
        public int ExamID { get; set; }
        public int StudentID { get; set; }
        public int CurseID { get; set; }
        public string Marks { get; set; }
        public virtual Exam Exam { get; set; }
    }
}