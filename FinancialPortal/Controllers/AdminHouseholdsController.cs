using FinancialPortal.Models;
using FinancialPortal.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialPortal.Controllers
{
    public class AdminHouseholdsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminHouseholds
        public ActionResult Index()
        {
            return View(db.Households.Include("Users").ToList());
        }


        //GET: AddUser
        public ActionResult AddToHouse(int id)
        {
            var house = db.Households.Find(id);
            AdminHousehold AdminHousehold = new AdminHousehold();
            HouseholdHelper helper = new HouseholdHelper();
            var selected = house.Users;
            AdminHousehold.Users = new MultiSelectList(db.Users, "Id", "FullName", selected);
            AdminHousehold.Household = house;
            return View(AdminHousehold);

        }

        //POST: AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToHouse(AdminHousehold model)
        {

            HouseholdHelper helper = new HouseholdHelper();
            //foreach (var userrmv in dB.Users.Select(r => r.Id).ToList())
            //{
            //    helper.RemoveUserFromProject(userrmv, model.Project.Id );
            //}

            foreach (var useradd in model.SelectedUsers)
            {
                helper.AddUserToHouse(useradd, model.Household.Id);
            }
            return RedirectToAction("Index", "Households");
        }


        //GET: RemoveUser
        public ActionResult RemoveFromHouse(int id, string userId)
        {
            var house = db.Households.Find(id);
            AdminHousehold AdminHousehold = new AdminHousehold();
            //HouseholdHelper helper = new HouseholdHelper();
            var selected = userId;
            AdminHousehold.RmvUser = db.Users.Find(userId);
            AdminHousehold.Household = house;
            return View(AdminHousehold);

        }

        //POST: AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromHouse(AdminHousehold model)
        {
            var house = db.Households.Find(model.Household.Id);
            var usr = db.Users.Find(model.RmvUser.Id);
            house.Users.Remove(usr);
            db.SaveChanges();
            
            return RedirectToAction("Index", "Households");
        }




    }
}