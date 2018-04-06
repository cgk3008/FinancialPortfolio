namespace FinancialPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Invite
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Email { get; set; }
        public Guid HHToken { get; set; }
        public DateTimeOffset InviteDate { get; set; }
        [StringLength(128)]
        public string InvitedById { get; set; }
        public bool HasBeenUsed { get; set; } //invite has been used because person is in household now
        public virtual ApplicationUser Users { get; set; }  //change to ApplicationUser
        public virtual Household Household { get; set; }
    }
}
