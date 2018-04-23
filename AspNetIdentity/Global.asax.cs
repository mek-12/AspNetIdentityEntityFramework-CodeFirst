using AspNetIdentity.Dal;
using AspNetIdentity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspNetIdentity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MyDbContext db = new MyDbContext();
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(roleStore);

            if(!roleManager.RoleExists("Admin"))
            {
                ApplicationRole adminRole = new ApplicationRole("Admin", "Sistem yöneticisi");
                roleManager.Create(adminRole);
            }

            if (!roleManager.RoleExists("User"))
            {
                ApplicationRole userRole = new ApplicationRole("User", "Normal kullanıcı");
                roleManager.Create(userRole);
            }
        }
    }
}
