using AspNetIdentity.Dal;
using AspNetIdentity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.Controllers
{
    public class HomeController : Controller
    {

        private MyDbContext db;
        private UserManager<ApplicationUser> usermanager;

        public HomeController()
        {
            db = new MyDbContext();
            usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = usermanager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewData["LoginUserName"] = currentUser.FirstName;
            return View();
        }

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