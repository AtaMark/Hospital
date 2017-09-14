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
    public class Sales_lineController : Controller
    {
        private HOSPITALEntities db = new HOSPITALEntities();

        // GET: Sales_line
        public ActionResult Index()
        {
            var sales_line = db.Sales_line.Include(s => s.Sales_header);
            return View(sales_line.ToList());
        }

        // GET: Sales_line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_line sales_line = db.Sales_line.Find(id);
            if (sales_line == null)
            {
                return HttpNotFound();
            }
            return View(sales_line);
        }

        // GET: Sales_line/Create
        public ActionResult Create()
        {
            ViewBag.Sales_header_idSales_header = new SelectList(db.Sales_header, "idSales_header", "customerID");
            return View();
        }

        // POST: Sales_line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSales_line,type,no,description,quantity,amount,Sales_header_idSales_header")] Sales_line sales_line)
        {
            if (ModelState.IsValid)
            {
                db.Sales_line.Add(sales_line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sales_header_idSales_header = new SelectList(db.Sales_header, "idSales_header", "customerID", sales_line.Sales_header_idSales_header);
            return View(sales_line);
        }

        // GET: Sales_line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_line sales_line = db.Sales_line.Find(id);
            if (sales_line == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sales_header_idSales_header = new SelectList(db.Sales_header, "idSales_header", "customerID", sales_line.Sales_header_idSales_header);
            return View(sales_line);
        }

        // POST: Sales_line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSales_line,type,no,description,quantity,amount,Sales_header_idSales_header")] Sales_line sales_line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sales_header_idSales_header = new SelectList(db.Sales_header, "idSales_header", "customerID", sales_line.Sales_header_idSales_header);
            return View(sales_line);
        }

        // GET: Sales_line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_line sales_line = db.Sales_line.Find(id);
            if (sales_line == null)
            {
                return HttpNotFound();
            }
            return View(sales_line);
        }

        // POST: Sales_line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales_line sales_line = db.Sales_line.Find(id);
            db.Sales_line.Remove(sales_line);
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
