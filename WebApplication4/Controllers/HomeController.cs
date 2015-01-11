using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            IdentityManager manager = new IdentityManager();
            //var suc = manager.CreateRole("Admin");
            return View();
        }
        [Authorize(Roles="Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}