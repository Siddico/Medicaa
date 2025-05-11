﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project_hospital_management_system.Models;

namespace project_hospital_management_system.Controllers
{
    public class PrescriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prescription
        public ActionResult Index()
        {
            var prescriptions = db.Prescriptions.Include(p => p.Doctor).Include(p => p.Patient).Include(p => p.Medication);
            return View(prescriptions.ToList());
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Include(p => p.Doctor).Include(p => p.Patient).Include(p => p.Medication)
                .FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: Prescription/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name");
            return View();
        }

        // POST: Prescription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrescriptionId,PatientId,DoctorId,MedicationId,DateIssued,Instructions")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", prescription.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", prescription.PatientId);
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name", prescription.MedicationId);
            return View(prescription);
        }

        // GET: Prescription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", prescription.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", prescription.PatientId);
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name", prescription.MedicationId);
            return View(prescription);
        }

        // POST: Prescription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrescriptionId,PatientId,DoctorId,MedicationId,DateIssued,Instructions")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", prescription.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", prescription.PatientId);
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name", prescription.MedicationId);
            return View(prescription);
        }

        // GET: Prescription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Include(p => p.Doctor).Include(p => p.Patient).Include(p => p.Medication)
                .FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(prescription);
            db.SaveChanges();
            return RedirectToAction("Index");
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
