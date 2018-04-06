using FinancialPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialPortal.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext dB = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = dB.Users.Find(userId);
            var userHouseholdId = dB.Users
            var householdName = dB.Households.Where(h => h.Users.F == userId);
            var userPersonalAccounts = dB.PersonalAccounts.Where( p => p.CreatedById == userId);
            var userTransactions = dB.Transactions.Where(t => t.User.Id == userId /*|| t.OwnerUserId == householdId*/ ).ToList();
            var userHousehold = dB.Households.Where(n => n.Users.Where(u => u.Id == userId));
            var userInvites = dB.Invites.Where(i => i.Users.Id == userId);

            DashViewModel model = new DashViewModel()
            {
                PersonalAccounts = userPersonalAccounts,
                Transactions = userTransactions,
                Invites = userInvites,
                Households = householdName
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}