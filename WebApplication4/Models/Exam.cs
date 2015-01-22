using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Exam
    {
        [Required]
        public int ExamID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual ExamType ExamType { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }

    }
}