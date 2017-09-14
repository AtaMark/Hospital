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
    public class Lab_test_linesController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Lab_test_lines
        public ActionResult Index()
        {
            var lab_test_lines = db.Lab_test_lines.Include(l => l.Pharmacy);
            return View(lab_test_lines.ToList());
        }

        // GET: Lab_test_lines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_test_lines lab_test_lines = db.Lab_test_lines.Find(id);
            if (lab_test_lines == null)
            {
                return HttpNotFound();
            }
            return View(lab_test_lines);
        }

        // GET: Lab_test_lines/Create
        public ActionResult Create()
        {
            ViewBag.Lab_test_reagentID = new SelectList(db.Pharmacies, "idDrug", "drug_description");
            return View();
        }

        // POST: Lab_test_lines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLab_test_lines,Lab_test_reagentID,Lab_test_time,Lab_test_drug_quantity,Lab_test_UOM,Lab_test_cost")] Lab_test_lines lab_test_lines)
        {
            if (ModelState.IsValid)
            {
                db.Lab_test_lines.Add(lab_test_lines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lab_test_reagentID = new SelectList(db.Pharmacies, "idDrug", "drug_description", lab_test_lines.Lab_test_reagentID);
            return View(lab_test_lines);
        }

        // GET: Lab_test_lines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_test_lines lab_test_lines = db.Lab_test_lines.Find(id);
            if (lab_test_lines == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lab_test_reagentID = new SelectList(db.Pharmacies, "idDrug", "drug_description", lab_test_lines.Lab_test_reagentID);
            return View(lab_test_lines);
        }

        // POST: Lab_test_lines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLab_test_lines,Lab_test_reagentID,Lab_test_time,Lab_test_drug_quantity,Lab_test_UOM,Lab_test_cost")] Lab_test_lines lab_test_lines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab_test_lines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lab_test_reagentID = new SelectList(db.Pharmacies, "idDrug", "drug_description", lab_test_lines.Lab_test_reagentID);
            return View(lab_test_lines);
        }

        // GET: Lab_test_lines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_test_lines lab_test_lines = db.Lab_test_lines.Find(id);
            if (lab_test_lines == null)
            {
                return HttpNotFound();
            }
            return View(lab_test_lines);
        }

        // POST: Lab_test_lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab_test_lines lab_test_lines = db.Lab_test_lines.Find(id);
            db.Lab_test_lines.Remove(lab_test_lines);
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
