using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using project_hospital_management_system.Models;

namespace project_hospital_management_system.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            // Get counts for dashboard
            ViewBag.PatientCount = db.Patients.Count();
            ViewBag.DoctorCount = db.Doctors.Count();
            ViewBag.AppointmentCount = db.Appointments.Count();
            ViewBag.MedicationCount = db.Medications.Count();
            ViewBag.PrescriptionCount = db.Prescriptions.Count();
            ViewBag.InvoiceCount = db.Invoices.Count();

            // Get today's appointments
            ViewBag.TodaysAppointments = db.Appointments
                .Where(a => a.AppointmentDate.Date == DateTime.Today)
                .OrderBy(a => a.AppointmentDate)
                .Take(5)
                .ToList();

            // Get pending invoices
            ViewBag.PendingInvoices = db.Invoices
                .Where(i => i.Status == "Pending")
                .OrderByDescending(i => i.DateIssued)
                .Take(5)
                .ToList();

            // Get recent prescriptions
            ViewBag.RecentPrescriptions = db.Prescriptions
                .OrderByDescending(p => p.DateIssued)
                .Take(5)
                .ToList();

            // Get user role for role-specific dashboard
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = UserManager.FindById(userId);

                if (user != null)
                {
                    ViewBag.UserFullName = user.FirstName + " " + user.LastName;
                    ViewBag.UserRole = UserManager.GetRoles(userId).FirstOrDefault() ?? "User";
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "About Hospital Management System";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}