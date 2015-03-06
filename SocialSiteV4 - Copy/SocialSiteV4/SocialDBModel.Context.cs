﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialSiteV4.Models;

namespace SocialSiteV4
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class SocialDBContext : IdentityDbContext<ApplicationUser>
    {
        public SocialDBContext()
            : base("name=SocialDBContext")
        {
            Database.SetInitializer<SocialDBContext>(new SchoolDBInitializer());
        }

        public static SocialDBContext Create()
        {
            return new SocialDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
    }

    public class SchoolDBInitializer : DropCreateDatabaseAlways<SocialDBContext>
    {
        protected override void Seed(SocialDBContext context)
        {
            if (!(context.AspNetUsers.Any(u => u.UserName.Equals("blake@blake.com"))))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser
                {
                    UserName = "blake@blake.com",
                    Email = "blake@blake.com"
                };
                userManager.Create(userToInsert, "P@$$w0rd");
            }

            base.Seed(context);
        }
    }
}
