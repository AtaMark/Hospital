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
    public class BedsController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Beds
        public ActionResult Index()
        {
            var beds = db.Beds.Include(b => b.Department).Include(b => b.Ward);
            return View(beds.ToList());
        }

        // GET: Beds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bed bed = db.Beds.Find(id);
            if (bed == null)
            {
                return HttpNotFound();
            }
            return View(bed);
        }

        // GET: Beds/Create
        public ActionResult Create()
        {
            ViewBag.id_department = new SelectList(db.Departments, "idDepartment", "department_description");
            ViewBag.id_ward = new SelectList(db.Wards, "idWard", "ward_description");
            return View();
        }

        // POST: Beds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBed,id_department,id_ward,bed_status")] Bed bed)
        {
            if (ModelState.IsValid)
            {
                db.Beds.Add(bed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_department = new SelectList(db.Departments, "idDepartment", "department_description", bed.id_department);
            ViewBag.id_ward = new SelectList(db.Wards, "idWard", "ward_description", bed.id_ward);
            return View(bed);
        }

        // GET: Beds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bed bed = db.Beds.Find(id);
            if (bed == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_department = new SelectList(db.Departments, "idDepartment", "department_description", bed.id_department);
            ViewBag.id_ward = new SelectList(db.Wards, "idWard", "ward_description", bed.id_ward);
            return View(bed);
        }

        // POST: Beds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBed,id_department,id_ward,bed_status")] Bed bed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_department = new SelectList(db.Departments, "idDepartment", "department_description", bed.id_department);
            ViewBag.id_ward = new SelectList(db.Wards, "idWard", "ward_description", bed.id_ward);
            return View(bed);
        }

        // GET: Beds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bed bed = db.Beds.Find(id);
            if (bed == null)
            {
                return HttpNotFound();
            }
            return View(bed);
        }

        // POST: Beds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bed bed = db.Beds.Find(id);
            db.Beds.Remove(bed);
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
