using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebApplication4.Models
{
    public class Question
    {
        [Required]
        public int QuestionID { get; set; }
        public string Desc { get; set; }
        public string DescA { get; set; }
        public string DescB { get; set; }
        public string DescC { get; set; }
        public string DescD { get; set; }
        public int Correct { get; set; }
        public int Value { get; set; }
        [Required]
        public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }
        
    }
}
