using FinancialPortal.Models;
using FinancialPortal.Models.Helper;
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
            //var userId = User.Identity.GetUserId();
            //var user = dB.Users.Find(userId);
            ////var userHouseholdId = dB.Users
            ////var householdName = dB.Households.Where(h => h.Users.F == userId);
            //var userPersonalAccounts = dB.PersonalAccounts.Where( p => p.CreatedById == userId);
            //var userTransactions = dB.Transactions.Where(t => t.User.Id == userId /*|| t.OwnerUserId == householdId*/ ).ToList();
            ////var userHousehold = dB.Households.Where(n => n.Users.Where(u => u.Id == userId));
            //var userInvites = dB.Invites.Where(i => i.Users.Id == userId);

            //DashViewModel model = new DashViewModel()
            //{
            //    PersonalAccounts = userPersonalAccounts,
            //    Transactions = userTransactions,
            //    Invites = userInvites,
            //    //Households = householdName
            //};


            return View(/*model)*/);
        }

        ////POST:AssignResident

        ////I am trying to add role fo "Resident" to all users in database with a click of button or action link.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AssignRoleResident(HouseholdRolesView model)
        //{
        //    var user = dB.Users.Find(User.Identity.GetUserId());
        //    UserManager.AddToRole(user.Id, "Resident");
        //    return RedirectToAction("Index");
        //}




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