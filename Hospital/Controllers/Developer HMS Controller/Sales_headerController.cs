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
    public class Sales_headerController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Sales_header
        public ActionResult Index()
        {
            return View(db.Sales_header.ToList());
        }

        // GET: Sales_header/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_header sales_header = db.Sales_header.Find(id);
            if (sales_header == null)
            {
                return HttpNotFound();
            }
            return View(sales_header);
        }

        // GET: Sales_header/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales_header/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSales_header,customerID,customer_name,posting_date")] Sales_header sales_header)
        {
            if (ModelState.IsValid)
            {
                db.Sales_header.Add(sales_header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sales_header);
        }

        // GET: Sales_header/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_header sales_header = db.Sales_header.Find(id);
            if (sales_header == null)
            {
                return HttpNotFound();
            }
            return View(sales_header);
        }

        // POST: Sales_header/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSales_header,customerID,customer_name,posting_date")] Sales_header sales_header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales_header);
        }

        // GET: Sales_header/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_header sales_header = db.Sales_header.Find(id);
            if (sales_header == null)
            {
                return HttpNotFound();
            }
            return View(sales_header);
        }

        // POST: Sales_header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales_header sales_header = db.Sales_header.Find(id);
            db.Sales_header.Remove(sales_header);
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
