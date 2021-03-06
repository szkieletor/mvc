﻿using System.Collections;
using System.Collections.Generic;
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

    public class ClassroomViewModel
    {
        public string Name { get; set; }
        public int startYear { get; set; }
        public int ClassTeacherID { get; set; } //Wychowawca
        public IEnumerable<ApplicationUser> Teachers { get; set; }

    }
    public class UserWithRolesViewModel
    {
        public UserViewModel User { get; set; }
        public RoleViewModel Admin { get; set; }
        public RoleViewModel Student { get; set; }
        public RoleViewModel Teacher { get; set; }
        public RoleViewModel Parent { get; set; }

        public UserWithRolesViewModel()
        {
            User = new UserViewModel();
            Admin = new RoleViewModel();
            Student = new RoleViewModel();
            Teacher = new RoleViewModel();
            Parent = new RoleViewModel();
        }
    }
}