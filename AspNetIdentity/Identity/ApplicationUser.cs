using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetIdentity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetIdentity.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }
}