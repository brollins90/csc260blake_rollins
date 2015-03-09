using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace SocialSiteV4_2.Models
{
    public class SocialDbContext : IdentityDbContext<ApplicationUser>
    {
        public SocialDbContext()
            : base("name=SocialDBContext", throwIfV1Schema: false)
        {
            Database.SetInitializer<SocialDbContext>(new SocialDbInitializer());
        }

        public static SocialDbContext Create()
        {
            return new SocialDbContext();
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        //public virtual DbSet<News> Newses { get; set; }
    }

    public class SocialDbInitializer : DropCreateDatabaseIfModelChanges<SocialDbContext>
    {
        protected override void Seed(SocialDbContext context)
        {
            try
            {
                // set this so the load works.  since the store is empty when the managers are created, it needs to be loadable
                context.Configuration.LazyLoadingEnabled = true;

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Administrator"))
                {
                    roleManager.Create(new IdentityRole("Administrator"));
                }

                if (!roleManager.RoleExists("User"))
                {
                    roleManager.Create(new IdentityRole("User"));
                }

                if (userManager.FindByEmail("admin@blake.com") == null)
                {
                    var userToInsert = new ApplicationUser
                    {
                        UserName = "admin@blake.com",
                        Email = "admin@blake.com",
                        Profile = new Profile()
                    };

                    var result = userManager.Create(userToInsert, "P@$$w0rd");
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(userToInsert.Id, "Administrator");
                    }
                }

                if (userManager.FindByEmail("blake@blake.com") == null)
                {
                    var userToInsert = new ApplicationUser
                    {
                        UserName = "blake@blake.com",
                        Email = "blake@blake.com",
                        Profile = new Profile()
                    };

                    var result = userManager.Create(userToInsert, "P@$$w0rd");
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(userToInsert.Id, "User");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Seeding broke");
            }

            base.Seed(context);
        }
    }
}