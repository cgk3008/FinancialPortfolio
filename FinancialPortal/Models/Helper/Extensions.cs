﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace FinancialPortal.Models.Helper
{
    public static class Extensions
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        
        public static string GetFullName(this IIdentity user)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

            var ClaimsUser = (ClaimsIdentity)user;
            var claim = ClaimsUser.Claims.FirstOrDefault(c => c.Type == "Name");
            if (claim != null)
            {
                return claim.Value;

            }
            else
            {
                return null;
            }
        }


        




    }
}