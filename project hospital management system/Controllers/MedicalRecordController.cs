﻿﻿using System;
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
    public class MedicalRecordController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalRecord
        public ActionResult Index()
        {
            var medicalRecords = db.MedicalRecords.Include(m => m.Doctor).Include(m => m.Patient);
            return View(medicalRecords.ToList());
        }

        // GET: MedicalRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord medicalRecord = db.MedicalRecords.Include(m => m.Doctor).Include(m => m.Patient).FirstOrDefault(m => m.RecordId == id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }

        // GET: MedicalRecord/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            return View();
        }

        // POST: MedicalRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,PatientId,DoctorId,Diagnosis,Treatment,RecordDate")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                db.MedicalRecords.Add(medicalRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", medicalRecord.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", medicalRecord.PatientId);
            return View(medicalRecord);
        }

        // GET: MedicalRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord medicalRecord = db.MedicalRecords.Find(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", medicalRecord.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", medicalRecord.PatientId);
            return View(medicalRecord);
        }

        // POST: MedicalRecord/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,PatientId,DoctorId,Diagnosis,Treatment,RecordDate")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", medicalRecord.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", medicalRecord.PatientId);
            return View(medicalRecord);
        }

        // GET: MedicalRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord medicalRecord = db.MedicalRecords.Include(m => m.Doctor).Include(m => m.Patient).FirstOrDefault(m => m.RecordId == id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }

        // POST: MedicalRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalRecord medicalRecord = db.MedicalRecords.Find(id);
            db.MedicalRecords.Remove(medicalRecord);
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
