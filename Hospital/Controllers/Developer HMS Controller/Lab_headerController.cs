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
    public class Lab_headerController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Lab_header
        public ActionResult Index()
        {
            var lab_header = db.Lab_header.Include(l => l.Visit).Include(l => l.User);
            return View(lab_header.ToList());
        }

        // GET: Lab_header/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_header lab_header = db.Lab_header.Find(id);
            if (lab_header == null)
            {
                return HttpNotFound();
            }
            return View(lab_header);
        }

        // GET: Lab_header/Create
        public ActionResult Create()
        {
            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID");
            ViewBag.userID = new SelectList(db.Users, "idUser", "name");
            return View();
        }

        // POST: Lab_header/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLab_header,userID,visitID,lab_test_date,lab_test_time")] Lab_header lab_header)
        {
            if (ModelState.IsValid)
            {
                db.Lab_header.Add(lab_header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID", lab_header.visitID);
            ViewBag.userID = new SelectList(db.Users, "idUser", "name", lab_header.userID);
            return View(lab_header);
        }

        // GET: Lab_header/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_header lab_header = db.Lab_header.Find(id);
            if (lab_header == null)
            {
                return HttpNotFound();
            }
            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID", lab_header.visitID);
            ViewBag.userID = new SelectList(db.Users, "idUser", "name", lab_header.userID);
            return View(lab_header);
        }

        // POST: Lab_header/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLab_header,userID,visitID,lab_test_date,lab_test_time")] Lab_header lab_header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab_header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID", lab_header.visitID);
            ViewBag.userID = new SelectList(db.Users, "idUser", "name", lab_header.userID);
            return View(lab_header);
        }

        // GET: Lab_header/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_header lab_header = db.Lab_header.Find(id);
            if (lab_header == null)
            {
                return HttpNotFound();
            }
            return View(lab_header);
        }

        // POST: Lab_header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab_header lab_header = db.Lab_header.Find(id);
            db.Lab_header.Remove(lab_header);
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
