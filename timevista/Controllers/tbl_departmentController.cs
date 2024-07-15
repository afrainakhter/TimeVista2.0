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
    public class tbl_departmentController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: tbl_department
        public ActionResult Index()
        {
            return View(db.tbl_department.ToList());

        }

        // GET: tbl_department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_department tbl_department = db.tbl_department.Find(id);
            if (tbl_department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_department);


        }


        public ActionResult ADashboard()
        {
            ViewBag.TotalDepartments = db.tbl_department.Count(); // Counting total departments

            // Fetch other data as needed

            return View();
        }

        // GET: tbl_department/Create
        public ActionResult Create()
        {

           
            return View();
        }

        // POST: tbl_department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,department_id,department_name,status,created_at")] tbl_department tbl_department)
        {
            if (ModelState.IsValid)
            {
                db.tbl_department.Add(tbl_department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_department);
        }

        // GET: tbl_department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_department tbl_department = db.tbl_department.Find(id);
            if (tbl_department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_department);
        }

        // POST: tbl_department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,department_id,department_name,status,created_at")] tbl_department tbl_department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_department);
        }

        // GET: tbl_department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_department tbl_department = db.tbl_department.Find(id);
            if (tbl_department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_department);
        }

        // POST: tbl_department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_department tbl_department = db.tbl_department.Find(id);
            db.tbl_department.Remove(tbl_department);
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
