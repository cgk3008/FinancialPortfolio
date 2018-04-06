using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models.Helper
{
    public static class UserHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string GetUserName(string userId)
        {
            ApplicationUser user = db.Users.Find(userId);
            return user.FullName;
        }
    }
}