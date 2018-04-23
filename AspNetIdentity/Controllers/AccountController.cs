using AspNetIdentity.Dal;
using AspNetIdentity.Identity;
using AspNetIdentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            MyDbContext db = new MyDbContext();

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = model.Username;
                user.FirstName = model.Name;
                user.LastName = model.Surname;
                user.PasswordHash = model.Password;

                IdentityResult iresult = userManager.Create(user, model.Password);

                if (iresult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProps,identity);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUser", "Böyle bir kullanıcı bulunamadı");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}