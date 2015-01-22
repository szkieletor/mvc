using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public int Year { get; set; }
        public int ClassTeacherID { get; set; } //Wychowawca
        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<ApplicationUser> Students { get; set; }

    }
}