using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Models
{
    public class AdminViewModels
    {

    }

    public class RoleViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserViewModel
    {
        public string UserName { get; set; }
    }

    public class UserWithRolesViewModel
    {
        public UserViewModel User { get; set; }
        public List<RoleViewModel> Roles { get; set; }

        public UserWithRolesViewModel()
        {
            User = new UserViewModel();
            Roles = new List<RoleViewModel>();
        }
    }

    public class RolesViewModel
    {
        public List<UserWithRolesViewModel> RolesByUser { get; set; }

        public RolesViewModel()
        {
            RolesByUser = new List<UserWithRolesViewModel>();
        }
    }

}