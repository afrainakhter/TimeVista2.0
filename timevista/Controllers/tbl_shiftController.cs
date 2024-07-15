using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeVista2._0.Models;

namespace TimeVista2._0.Controllers
{
    public class tbl_shiftController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: tbl_shift
        public ActionResult Index()
        {
            return View(db.tbl_shift.ToList());
        }

        // GET: tbl_shift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_shift tbl_shift = db.tbl_shift.Find(id);
            if (tbl_shift == null)
            {
                return HttpNotFound();
            }
            return View(tbl_shift);
        }

        // GET: tbl_shift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_shift/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,start_time,end_time,status,created_at")] tbl_shift tbl_shift)
        {
            if (ModelState.IsValid)
            {
                db.tbl_shift.Add(tbl_shift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_shift);
        }

        // GET: tbl_shift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_shift tbl_shift = db.tbl_shift.Find(id);
            if (tbl_shift == null)
            {
                return HttpNotFound();
            }
            return View(tbl_shift);
        }

        // POST: tbl_shift/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,start_time,end_time,status,created_at")] tbl_shift tbl_shift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_shift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_shift);
        }

        // GET: tbl_shift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_shift tbl_shift = db.tbl_shift.Find(id);
            if (tbl_shift == null)
            {
                return HttpNotFound();
            }
            return View(tbl_shift);
        }

        // POST: tbl_shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_shift tbl_shift = db.tbl_shift.Find(id);
            db.tbl_shift.Remove(tbl_shift);
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
