﻿using Core.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Book> Books { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public UserStatus Status { get; set; }
        public bool IsBanned { get; set; }
        public virtual File Avatar { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
