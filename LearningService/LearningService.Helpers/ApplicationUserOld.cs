﻿using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearningService.Helpers
{
    //public class ApplicationUserOld : IdentityUser
    //{
    //    public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserOld> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }

    //    public virtual string Name { get; set; }
    //    public virtual string Surname { get; set; }
    //    public virtual bool Active { get; set; }
        
    //    public ApplicationUserOld()
    //    {

    //    }

    //    public ApplicationUserOld(string userId)
    //    {
    //        this.Id = userId;
    //    }
    //}
}