using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }


        public void UpdateUserRoles(UserWithRolesViewModel changedUserData)
        {
            var manager = new IdentityManager();
            var user = manager.GetUserByName(changedUserData.User.UserName);
            manager.ClearUserRoles(user.Id);
            if (changedUserData.Admin.IsActive) manager.AddUserToRole(user.Id, "Admin");
            if (changedUserData.Teacher.IsActive) manager.AddUserToRole(user.Id, "Teacher");
            if (changedUserData.Student.IsActive) manager.AddUserToRole(user.Id, "Student");
            if (changedUserData.Parent.IsActive) manager.AddUserToRole(user.Id, "Parent");
        }


        public JsonResult GetRoles()
        {
            var manager = new IdentityManager();
            var users = manager.GetAllUsers();
            var userList = new List<UserWithRolesViewModel>();
            foreach (var user in users)
            {
                var userWithRolesViewModel = new UserWithRolesViewModel();
                var userViewModel = new UserViewModel {UserName = user.UserName};
                userWithRolesViewModel.User = userViewModel;

                userWithRolesViewModel.Admin.Name = "Admin";
                if (user.Roles.FirstOrDefault(r => r.Role.Name == "Admin") != null) userWithRolesViewModel.Admin.IsActive = true;
                else userWithRolesViewModel.Admin.IsActive = false;

                userWithRolesViewModel.Student.Name = "Student";
                if (user.Roles.FirstOrDefault(r => r.Role.Name == "Student") != null) userWithRolesViewModel.Student.IsActive = true;
                else userWithRolesViewModel.Student.IsActive = false;

                userWithRolesViewModel.Teacher.Name = "Teacher";
                if (user.Roles.FirstOrDefault(r => r.Role.Name == "Teacher") != null) userWithRolesViewModel.Teacher.IsActive = true;
                else userWithRolesViewModel.Teacher.IsActive = false;

                userWithRolesViewModel.Parent.Name = "Parent";
                if (user.Roles.FirstOrDefault(r => r.Role.Name == "Parent") != null) userWithRolesViewModel.Parent.IsActive = true;
                else userWithRolesViewModel.Parent.IsActive = false;

                userList.Add(userWithRolesViewModel);
            }

            return Json(userList);
        }

        public ActionResult AddClassroom()
        {

            var service = new TeacherService();
            IEnumerable<ApplicationUser> teachers = service.GetAllTeachers();
            var classroom = new ClassroomViewModel()
            {
                Teachers = teachers
            };
            return View(classroom);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddClassroom(ClassroomViewModel model)
        {
            var service = new ClassroomService();
            var classroom = new Classroom()
            {

            };
            service.AddClassroom(classroom);
            return View("Index");
        }
    }
}