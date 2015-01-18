using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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