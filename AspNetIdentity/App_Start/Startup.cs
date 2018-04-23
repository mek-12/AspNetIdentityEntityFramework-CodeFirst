using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(AspNetIdentity.App_Start.Startup))]

namespace AspNetIdentity.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
                CookieHttpOnly = true,
                CookieSecure = Microsoft.Owin.Security.Cookies.CookieSecureOption.Always
            });
        }
    }
}