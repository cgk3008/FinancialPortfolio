using FinancialPortal.Models;
using FinancialPortal.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialPortal.Controllers
{
    public class HouseholdRolesViewsController : Controller
    {
        
        private ApplicationDbContext dB = new ApplicationDbContext();

        // GET: HouseholdRolesViews
        public ActionResult Index()
        {
            List<HouseholdRolesView> model = new List<HouseholdRolesView>();
            UserHelper helper = new UserHelper();

            foreach (var User in dB.Users)
            {
                HouseholdRolesView vm = new HouseholdRolesView();
                vm.User = User;
                vm.RoleList = helper.ListRolesForUser(User.Id);
                model.Add(vm);
            }
            return View(model);


        }

        //GET: EditUser
        public ActionResult EditUser(string id)
        {
            var user = dB.Users.Find(id);
            HouseholdRolesView AdminModel = new HouseholdRolesView();
            UserHelper helper = new UserHelper();
            var selected = helper.ListRolesForUser(id);
            AdminModel.Roles = new SelectList(dB.Roles, "Name", "Name", selected);
            AdminModel.User = new ApplicationUser
            {
                Id = user.Id,
                FullName = user.FullName
            };
            return View(AdminModel);

            //new { id = mod.User.Id })
        }

        //POST: EditUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(HouseholdRolesView model)
        {
            //var user = dB.Users.Find(model.id);
            UserHelper helper = new UserHelper();
            foreach (var rolermv in dB.Roles.Select(r => r.Name).ToList())
            {
                helper.RemoveUserFromRole(model.User.Id, rolermv);
            }
            foreach (var roleadd in model.SelectedRoles)
            {
                helper.AddUserToRole(model.User.Id, roleadd);
            }
            return RedirectToAction("Index");
        }



    }
}