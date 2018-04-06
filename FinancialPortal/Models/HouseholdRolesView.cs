using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialPortal.Models
{
    public class HouseholdRolesView
    {
        public ApplicationUser User { get; set; }
        //public ICollection<string> Roles { get; set; }
        public SelectList Roles { get; set; }
        public ICollection<string> RoleList { get; set; }
        public string[] SelectedRoles { get; set; }

        public Household Household { get; set; }
        public ICollection<string> Users { get; set; }


    }
}