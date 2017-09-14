using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.DataBase;

namespace Hospital.Controllers.Developer_HMS_Controller
{
    public class DiagnosisController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Diagnosis
        public ActionResult Index()
        {
            var diagnosis = db.Diagnosis.Include(d => d.Doctor);
            return View(diagnosis.ToList());
        }

        // GET: Diagnosis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return HttpNotFound();
            }
            return View(diagnosi);
        }

        // GET: Diagnosis/Create
        public ActionResult Create()
        {
            ViewBag.doctorID = new SelectList(db.Doctors, "idDoctor", "doctor_name");
            return View();
        }

        // POST: Diagnosis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDiagnosis,diagnosis_description,doctorID")] Diagnosi diagnosi)
        {
            if (ModelState.IsValid)
            {
                db.Diagnosis.Add(diagnosi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorID = new SelectList(db.Doctors, "idDoctor", "doctor_name", diagnosi.doctorID);
            return View(diagnosi);
        }

        // GET: Diagnosis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorID = new SelectList(db.Doctors, "idDoctor", "doctor_name", diagnosi.doctorID);
            return View(diagnosi);
        }

        // POST: Diagnosis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDiagnosis,diagnosis_description,doctorID")] Diagnosi diagnosi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnosi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorID = new SelectList(db.Doctors, "idDoctor", "doctor_name", diagnosi.doctorID);
            return View(diagnosi);
        }

        // GET: Diagnosis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return HttpNotFound();
            }
            return View(diagnosi);
        }

        // POST: Diagnosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            db.Diagnosis.Remove(diagnosi);
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
