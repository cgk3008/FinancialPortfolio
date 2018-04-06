namespace FinancialPortal.Migrations
{
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinancialPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinancialPortal.Models.ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole();

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Resident"))
            {
                role = new IdentityRole { Name = "Resident" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Head of Household"))
            {
                role = new IdentityRole { Name = "Head of Household" };
                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
        }
    }
}
