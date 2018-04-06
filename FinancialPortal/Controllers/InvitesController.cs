using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinancialPortal.Models;
using Microsoft.AspNet.Identity;

namespace FinancialPortal.Controllers
{
    public class InvitesController : Controller
    {
        private ApplicationDbContext dB= new ApplicationDbContext();

        // GET: Invites
        public ActionResult Index()
        {
            var invites = dB.Invites.Include(i => i.Household);
            return View(invites.ToList());
        }

        // GET: Invites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = dB.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // GET: Invites/Create
        public ActionResult Create()
        {
            ViewBag.HouseholdId = new SelectList(dB.Households, "Id", "Name");
            return View();
        }

        // POST: Invites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HouseholdId,Email,HHToken,InviteDate,InvitedById,HasBeenUsed")] Invite invite)
        {
            if (ModelState.IsValid)
            {
                dB.Invites.Add(invite);
                dB.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", invite.HouseholdId);
            //return View(invite);
            var household = dB.Invites.Find(invite.Id);
            household.Id = invite.HouseholdId;
            //var inviter = User.Identity.GetUserId();
            //var inviterEmail = dB.Users.Find(e => e.inviter);
           

            //try
            //{
            //    EmailService ems = new EmailService();
            //    IdentityMessage msg = new IdentityMessage();

            //    ApplicationUser user = dB.Users.Find(invite.InvitedById);

            //    msg.Body = "New Invite." + Environment.NewLine + "Please click the following link to view the details " + "<a href=\"" + callbackUrl + "\">NEW HOUSEHOLD INVITE</a>";

            //    //add logged user email in body of invite email so person can contact them if they have questions or issues

            //    msg.Destination = user.Email;
            //    msg.Subject = "Assigned Project";
            //    await ems.SendMailAsync(msg);
            //}
            //catch (Exception ex)
            //{
            //    await Task.FromResult(0);
            //}
            return RedirectToAction("Index");

        }

        // GET: Invites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = dB.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdId = new SelectList(dB.Households, "Id", "Name", invite.HouseholdId);
            return View(invite);
        }

        // POST: Invites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HouseholdId,Email,HHToken,InviteDate,InvitedById,HasBeenUsed")] Invite invite)
        {
            if (ModelState.IsValid)
            {
                dB.Entry(invite).State = EntityState.Modified;
                dB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdId = new SelectList(dB.Households, "Id", "Name", invite.HouseholdId);
            return View(invite);
        }

        // GET: Invites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = dB.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // POST: Invites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invite invite = dB.Invites.Find(id);
            dB.Invites.Remove(invite);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
