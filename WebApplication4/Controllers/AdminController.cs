using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

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

        public ActionResult AddUser()
        {

            return View();
        }

        public ActionResult Roles()
        {
            var manager = new IdentityManager();
            var roles = manager.GetAllRoles();
            var users = manager.GetAllUsers();
            var rolesViewModel = new RolesViewModel();
            foreach (var user in users)
            {
                var userWithRolesViewModel = new UserWithRolesViewModel();
                var userViewModel = new UserViewModel();
                userViewModel.UserName = user.UserName;
                userWithRolesViewModel.User = userViewModel;
                foreach (var role in roles)
                {
                    var roleViewModel = new RoleViewModel();
                    roleViewModel.Name = role.Name;
                    if (user.Roles.FirstOrDefault(r => r.Role.Name == role.Name) != null) roleViewModel.IsActive = true;
                    else roleViewModel.IsActive = false;
                    userWithRolesViewModel.Roles.Add(roleViewModel);
                }
                rolesViewModel.RolesByUser.Add(userWithRolesViewModel);
            }

            return PartialView(rolesViewModel);
        }
	}
}