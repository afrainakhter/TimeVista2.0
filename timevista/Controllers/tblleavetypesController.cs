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
    public class tblleavetypesController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: tblleavetypes
        public ActionResult Index()
        {
            return View(db.tblleavetypes.ToList());
        }

        // GET: tblleavetypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblleavetype tblleavetype = db.tblleavetypes.Find(id);
            if (tblleavetype == null)
            {
                return HttpNotFound();
            }
            return View(tblleavetype);
        }

        // GET: tblleavetypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblleavetypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,LeaveType,Description,CreationDate")] tblleavetype tblleavetype)
        {
            if (ModelState.IsValid)
            {
                db.tblleavetypes.Add(tblleavetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblleavetype);
        }

        // GET: tblleavetypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblleavetype tblleavetype = db.tblleavetypes.Find(id);
            if (tblleavetype == null)
            {
                return HttpNotFound();
            }
            return View(tblleavetype);
        }

        // POST: tblleavetypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,LeaveType,Description,CreationDate")] tblleavetype tblleavetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblleavetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblleavetype);
        }

        // GET: tblleavetypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblleavetype tblleavetype = db.tblleavetypes.Find(id);
            if (tblleavetype == null)
            {
                return HttpNotFound();
            }
            return View(tblleavetype);
        }

        // POST: tblleavetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblleavetype tblleavetype = db.tblleavetypes.Find(id);
            db.tblleavetypes.Remove(tblleavetype);
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
