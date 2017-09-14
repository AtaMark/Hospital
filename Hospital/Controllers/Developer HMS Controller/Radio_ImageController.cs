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
    public class Radio_ImageController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Radio_Image
        public ActionResult Index()
        {
            var radio_Image = db.Radio_Image.Include(r => r.Visit).Include(r => r.User);
            return View(radio_Image.ToList());
        }

        // GET: Radio_Image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radio_Image radio_Image = db.Radio_Image.Find(id);
            if (radio_Image == null)
            {
                return HttpNotFound();
            }
            return View(radio_Image);
        }

        // GET: Radio_Image/Create
        public ActionResult Create()
        {
            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID");
            ViewBag.userID = new SelectList(db.Users, "idUser", "name");
            return View();
        }

        // POST: Radio_Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRadio_Image,visitID,imageObservation,userID,image_date")] Radio_Image radio_Image)
        {
            if (ModelState.IsValid)
            {
                db.Radio_Image.Add(radio_Image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID", radio_Image.visitID);
            ViewBag.userID = new SelectList(db.Users, "idUser", "name", radio_Image.userID);
            return View(radio_Image);
        }

        // GET: Radio_Image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radio_Image radio_Image = db.Radio_Image.Find(id);
            if (radio_Image == null)
            {
                return HttpNotFound();
            }
            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID", radio_Image.visitID);
            ViewBag.userID = new SelectList(db.Users, "idUser", "name", radio_Image.userID);
            return View(radio_Image);
        }

        // POST: Radio_Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRadio_Image,visitID,imageObservation,userID,image_date")] Radio_Image radio_Image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radio_Image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.visitID = new SelectList(db.Visits, "idVisit", "patientID", radio_Image.visitID);
            ViewBag.userID = new SelectList(db.Users, "idUser", "name", radio_Image.userID);
            return View(radio_Image);
        }

        // GET: Radio_Image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radio_Image radio_Image = db.Radio_Image.Find(id);
            if (radio_Image == null)
            {
                return HttpNotFound();
            }
            return View(radio_Image);
        }

        // POST: Radio_Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radio_Image radio_Image = db.Radio_Image.Find(id);
            db.Radio_Image.Remove(radio_Image);
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
