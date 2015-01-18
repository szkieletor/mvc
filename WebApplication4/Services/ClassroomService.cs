using System;
using System.Linq;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class ClassroomService
    {
        public void AddClassroom(Classroom classroom)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Classrooms.Add(classroom);
                db.SaveChanges();
            }
        }

        public void RemoveClassroom(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var element = db.Classrooms.First(c => c.ClassroomID == id);
                db.Classrooms.Remove(element);
                db.SaveChanges();
            }
        }

        public void EditClassroom(Classroom classroom)
        {
            using (var db = new ApplicationDbContext())
            {
                var original = db.Classrooms.Find(classroom.ClassroomID);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(classroom);
                    db.SaveChanges();
                }
            }
        }

        public void AddClassTeacher(Classroom classroom, ApplicationUser teacher)
        {
            using (var db = new ApplicationDbContext())
            {
                var original = db.Classrooms.Find(classroom.ClassroomID);
                original.ClassTeacherID = Convert.ToInt32(teacher.Id);
                EditClassroom(classroom);
            }
        }
    }
}