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
    public class UOMsController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: UOMs
        public ActionResult Index()
        {
            return View(db.UOMs.ToList());
        }

        // GET: UOMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM uOM = db.UOMs.Find(id);
            if (uOM == null)
            {
                return HttpNotFound();
            }
            return View(uOM);
        }

        // GET: UOMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UOMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUOM,UOM_description,quantity_per_UOM")] UOM uOM)
        {
            if (ModelState.IsValid)
            {
                db.UOMs.Add(uOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uOM);
        }

        // GET: UOMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM uOM = db.UOMs.Find(id);
            if (uOM == null)
            {
                return HttpNotFound();
            }
            return View(uOM);
        }

        // POST: UOMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUOM,UOM_description,quantity_per_UOM")] UOM uOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uOM);
        }

        // GET: UOMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM uOM = db.UOMs.Find(id);
            if (uOM == null)
            {
                return HttpNotFound();
            }
            return View(uOM);
        }

        // POST: UOMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UOM uOM = db.UOMs.Find(id);
            db.UOMs.Remove(uOM);
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
