using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace srrdb.dbo.Account
{
    public class ApplicationUser : IdentityUser<int>
    {
        public DateTime RegistrationAt { get; set; } = DateTime.Now;

        //relations
        public ICollection<Srr> Srr { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }

    public class ApplicationRole : IdentityRole<int>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
    }
}
