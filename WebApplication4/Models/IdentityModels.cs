using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApplication4.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }

    public class IdentityManager
    {
        public RoleManager<IdentityRole> LocalRoleManager
        {
            get
            {
                return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            }
        }


        public UserManager<ApplicationUser> LocalUserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            }
        }

        public ApplicationUser GetUserByID(string userID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser user = null;

            var query = from u in db.Users
                        where u.Id == userID
                        select u;

            if (query.Count() > 0)
                user = query.First();

            return user;
        }


        public ApplicationUser GetUserByName(string username)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser user = null;

            var query = from u in db.Users
                        where u.UserName == username
                        select u;

            if (query.Count() > 0)
                user = query.First();

            return user;
        }

        public bool UserExists(string name)
        {
            var user = GetUserByName(name);
            if (user != null) return false;
            else return true;
        }

        public bool RoleExists(string name)
        {
            var rm = LocalRoleManager;

            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = LocalRoleManager;
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = LocalUserManager;
            var idResult = um.Create(user, password);

            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = LocalUserManager;
            var idResult = um.AddToRole(userId, roleName);

            return idResult.Succeeded;
        }


        public bool AddUserToRoleByUsername(string username, string roleName)
        {
            var um = LocalUserManager;

            string userID = um.FindByName(username).Id;
            var idResult = um.AddToRole(userID, roleName);

            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = LocalUserManager;
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.Roles);

            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.Role.Name);
            }
        }

        public List<IdentityRole> GetAllRoles()
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles.ToList();
            return roles;
        }



        public List<ApplicationUser> GetAllUsers()
        {
            var context = new ApplicationDbContext();
            var users = context.Users.ToList();
            return users;
        }
    }
}