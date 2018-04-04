using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinancialPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string DisplayName { get; set; }
        public int? HouseHoldId { get; set; }
        //[StringLength(256)]
        //public string Email{ get; set; }
        //public bool EmailConfirmed { get; set; }
        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        //public string PhoneNumber { get; set; }
        //public bool PhoneNumberConfirmed { get; set; }
        //public bool TwoFactorEnabled { get; set; }
        //public DateTime? LockoutEndDateUtc { get; set; } //change to DateTimeOffset??????
        //public bool LockoutEnabled { get; set; }
        //public int AccessFailedCount { get; set; }
        //[Required]
        //[StringLength(256)]
        //public string UserName { get; set; }
        public string FullName { get; set; }
        public string InviteEmail { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<PersonalAccount> PersonalAccounts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public ApplicationUser()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaim>();
            //AspNetUserLogins = new HashSet<AspNetUserLogin>();
            Invites = new HashSet<Invite>();
            PersonalAccounts = new HashSet<PersonalAccount>();
            Transactions = new HashSet<Transaction>();
            //AspNetRoles = new HashSet<AspNetRole>();
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Invite> invites { get; set; }
        public DbSet<PersonalAccount> personalAccounts { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<Budget> budgets { get; set; }
        public DbSet<BudgetItem> budgetItems { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Household> households{ get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

    }
}