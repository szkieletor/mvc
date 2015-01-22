using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class TeacherService
    {
        public List<ApplicationUser> GetAllTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var role = ctx.Roles.First(r => r.Name == "Teacher");
                var manager = new IdentityManager();
                var teachers = ctx.Users.Where(u => u.Roles.Any(r => r.Role == role)).ToList();
                return teachers;
            }
        } 
    }
}