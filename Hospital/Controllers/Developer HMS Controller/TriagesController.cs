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
    public class TriagesController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Triages
        public ActionResult Index()
        {
            var triages = db.Triages.Include(t => t.Visit);
            return View(triages.ToList());
        }

        // GET: Triages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Triage triage = db.Triages.Find(id);
            if (triage == null)
            {
                return HttpNotFound();
            }
            return View(triage);
        }

        // GET: Triages/Create
        public ActionResult Create()
        {
            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID");
            return View();
        }

        // POST: Triages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTriage,height,mass,blood_pressure,Triagecol,Visit_idVisit,checkup_cost")] Triage triage)
        {
            if (ModelState.IsValid)
            {
                db.Triages.Add(triage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID", triage.Visit_idVisit);
            return View(triage);
        }

        // GET: Triages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Triage triage = db.Triages.Find(id);
            if (triage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID", triage.Visit_idVisit);
            return View(triage);
        }

        // POST: Triages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTriage,height,mass,blood_pressure,Triagecol,Visit_idVisit,checkup_cost")] Triage triage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID", triage.Visit_idVisit);
            return View(triage);
        }

        // GET: Triages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Triage triage = db.Triages.Find(id);
            if (triage == null)
            {
                return HttpNotFound();
            }
            return View(triage);
        }

        // POST: Triages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Triage triage = db.Triages.Find(id);
            db.Triages.Remove(triage);
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
