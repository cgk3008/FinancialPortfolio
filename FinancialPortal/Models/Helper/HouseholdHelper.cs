using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models.Helper
{
    public class HouseholdHelper
    {


        private  ApplicationDbContext db = new ApplicationDbContext();

        public Exception AddUserToHouse(string userId, int houseId)
        {
            try
            {
                var house = db.Households.Find(houseId);
                var usr = db.Users.Find(userId);
                house.Users.Add(usr); 
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Exception RemoveUserToHouse(string userId, int houseId)
        {
            try
            {
                var house = db.Households.Find(houseId);
                var usr = db.Users.Find(userId);
                house.Users.Remove(usr); 
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public ICollection<ApplicationUser> ListUsersInHouse(int houseId)
        {
            return db.Households.Find(houseId).Users.ToList();
        }

        public ICollection<ApplicationUser> ListHouseholdHead(int houseId)
        {
            var head = db.Households.Find(houseId).HeadHousehold;
            var usr = db.Users.Find(head).FullName;

            return null;
        }





    }
}