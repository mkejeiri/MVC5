using System.Data.Entity.Migrations;
using System.Linq;
using AutomaticTellerMachine.Models;
using AutomaticTellerMachine.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutomaticTellerMachine.Customs
{
    public static class MyCustomConfig
    {
        public static void ApplySeed(this ApplicationDbContext context)
        {

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(t => t.UserName == "admin@mvcatm.com"))
            {
                var user = new ApplicationUser() { UserName = "admin@mvcatm.com", Email = "admin@mvcatm.com" };
                userManager.Create(user, "passw0rd!");
                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("Admin", "user", user.Id, 1000);
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(t => t.UserName == "mod@mvcatm.com"))
            {
                var user = new ApplicationUser() { UserName = "mod@mvcatm.com", Email = "mod@mvcatm.com" };
                userManager.Create(user, "passw0rd!");
                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("Moderator", "user", user.Id, 1000);
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Moderator" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Moderator");
            }

            if (!context.Users.Any(t => t.UserName == "pub@mvcatm.com"))
            {
                var user = new ApplicationUser() { UserName = "pub@mvcatm.com", Email = "pub@mvcatm.com" };
                userManager.Create(user, "passw0rd!");
                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("Public", "user", user.Id, 1000);
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Public" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Public");
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}