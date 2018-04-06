using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models
{
    public class DashViewModel
    {

        public IEnumerable<Household> Households { get; set; }
        public IEnumerable<PersonalAccount> PersonalAccounts { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Invite> Invites { get; set; }




    }
}