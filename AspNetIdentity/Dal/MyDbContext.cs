using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspNetIdentity.Identity;
using AspNetIdentity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetIdentity.Dal
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext():base("MyDbContext")
        {
            
        }

        public DbSet<Article> Articles { get; set; }

    }
}