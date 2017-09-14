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
    public class Follow_upController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Follow_up
        public ActionResult Index()
        {
            var follow_up = db.Follow_up.Include(f => f.Visit);
            return View(follow_up.ToList());
        }

        // GET: Follow_up/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow_up follow_up = db.Follow_up.Find(id);
            if (follow_up == null)
            {
                return HttpNotFound();
            }
            return View(follow_up);
        }

        // GET: Follow_up/Create
        public ActionResult Create()
        {
            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID");
            return View();
        }

        // POST: Follow_up/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFollow_up,description,follow_up_date,Follow_up_time,Visit_idVisit")] Follow_up follow_up)
        {
            if (ModelState.IsValid)
            {
                db.Follow_up.Add(follow_up);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID", follow_up.Visit_idVisit);
            return View(follow_up);
        }

        // GET: Follow_up/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow_up follow_up = db.Follow_up.Find(id);
            if (follow_up == null)
            {
                return HttpNotFound();
            }
            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID", follow_up.Visit_idVisit);
            return View(follow_up);
        }

        // POST: Follow_up/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFollow_up,description,follow_up_date,Follow_up_time,Visit_idVisit")] Follow_up follow_up)
        {
            if (ModelState.IsValid)
            {
                db.Entry(follow_up).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Visit_idVisit = new SelectList(db.Visits, "idVisit", "patientID", follow_up.Visit_idVisit);
            return View(follow_up);
        }

        // GET: Follow_up/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow_up follow_up = db.Follow_up.Find(id);
            if (follow_up == null)
            {
                return HttpNotFound();
            }
            return View(follow_up);
        }

        // POST: Follow_up/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Follow_up follow_up = db.Follow_up.Find(id);
            db.Follow_up.Remove(follow_up);
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
