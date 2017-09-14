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
    public class Lab_test_resultsController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Lab_test_results
        public ActionResult Index()
        {
            var lab_test_results = db.Lab_test_results.Include(l => l.Lab_header).Include(l => l.Lab_test_lines);
            return View(lab_test_results.ToList());
        }

        // GET: Lab_test_results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_test_results lab_test_results = db.Lab_test_results.Find(id);
            if (lab_test_results == null)
            {
                return HttpNotFound();
            }
            return View(lab_test_results);
        }

        // GET: Lab_test_results/Create
        public ActionResult Create()
        {
            ViewBag.Lab_headerID = new SelectList(db.Lab_header, "idLab_header", "userID");
            ViewBag.Lab_test_linesID = new SelectList(db.Lab_test_lines, "idLab_test_lines", "Lab_test_UOM");
            return View();
        }

        // POST: Lab_test_results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLab_test,Lab_test_description,Lab_headerID,Lab_test_linesID")] Lab_test_results lab_test_results)
        {
            if (ModelState.IsValid)
            {
                db.Lab_test_results.Add(lab_test_results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lab_headerID = new SelectList(db.Lab_header, "idLab_header", "userID", lab_test_results.Lab_headerID);
            ViewBag.Lab_test_linesID = new SelectList(db.Lab_test_lines, "idLab_test_lines", "Lab_test_UOM", lab_test_results.Lab_test_linesID);
            return View(lab_test_results);
        }

        // GET: Lab_test_results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_test_results lab_test_results = db.Lab_test_results.Find(id);
            if (lab_test_results == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lab_headerID = new SelectList(db.Lab_header, "idLab_header", "userID", lab_test_results.Lab_headerID);
            ViewBag.Lab_test_linesID = new SelectList(db.Lab_test_lines, "idLab_test_lines", "Lab_test_UOM", lab_test_results.Lab_test_linesID);
            return View(lab_test_results);
        }

        // POST: Lab_test_results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLab_test,Lab_test_description,Lab_headerID,Lab_test_linesID")] Lab_test_results lab_test_results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab_test_results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lab_headerID = new SelectList(db.Lab_header, "idLab_header", "userID", lab_test_results.Lab_headerID);
            ViewBag.Lab_test_linesID = new SelectList(db.Lab_test_lines, "idLab_test_lines", "Lab_test_UOM", lab_test_results.Lab_test_linesID);
            return View(lab_test_results);
        }

        // GET: Lab_test_results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_test_results lab_test_results = db.Lab_test_results.Find(id);
            if (lab_test_results == null)
            {
                return HttpNotFound();
            }
            return View(lab_test_results);
        }

        // POST: Lab_test_results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab_test_results lab_test_results = db.Lab_test_results.Find(id);
            db.Lab_test_results.Remove(lab_test_results);
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
