using System.ComponentModel.DataAnnotations;

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