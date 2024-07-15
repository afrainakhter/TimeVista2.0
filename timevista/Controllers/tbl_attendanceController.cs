using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimeVista2._0.Models;

namespace TimeVista2._0.Controllers
{
    public class tbl_attendanceController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: tbl_attendance
        public ActionResult Index()
        {
            var attendances = db.tbl_attendance.ToList();
            return View(attendances);
        }

        // GET: tbl_attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_attendance tbl_attendance = db.tbl_attendance.Find(id);
            if (tbl_attendance == null)
            {
                return HttpNotFound();
            }
            return View(tbl_attendance);
        }

        // GET: tbl_attendance/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = GetCurrentEmployeeId(); // Populate employee dropdown
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList(); // Populate shift dropdown
            return View();
        }

        // POST: tbl_attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_attendance tbl_attendance)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Set created_at date
                    tbl_attendance.created_at = DateTime.Now;

                    db.tbl_attendance.Add(tbl_attendance);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                }
            }

            // If model state is not valid, reload view with dropdown data
            ViewBag.EmployeeId = GetCurrentEmployeeId();
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList();
            return View(tbl_attendance);
        }

        // GET: tbl_attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_attendance tbl_attendance = db.tbl_attendance.Find(id);
            if (tbl_attendance == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmployeeId = GetCurrentEmployeeId(); // Populate employee dropdown
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList();
            return View(tbl_attendance);
        }

        // POST: tbl_attendance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_attendance tbl_attendance)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_attendance).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                }
            }

            // If model state is not valid, reload view with dropdown data
            ViewBag.EmployeeId = db.tbl_employee;
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList();
            return View(tbl_attendance);
        }

        // GET: tbl_attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_attendance tbl_attendance = db.tbl_attendance.Find(id);
            if (tbl_attendance == null)
            {
                return HttpNotFound();
            }
            return View(tbl_attendance);
        }

        // POST: tbl_attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_attendance tbl_attendance = db.tbl_attendance.Find(id);
            db.tbl_attendance.Remove(tbl_attendance);
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

        public string GetCurrentEmployeeId()
        {
            string employeeId = "";

            // Example: Retrieve employee ID from session if stored there
            if (@Session["EmployeeId"] != null)
            {
                employeeId = @Session["EmployeeId"].ToString();
            }
            else
            {
                // Example: Retrieve employee ID from database
                var employee = db.tbl_employee.FirstOrDefault(); // Adjust this query as per your database context and structure

                if (employee != null)
                {
                    employeeId = employee.employee_id;
                }
            }

            // Format the employee ID if retrieved
            if (!string.IsNullOrEmpty(employeeId))
            {
                employeeId = "EMP-" + employeeId;
            }

            return employeeId;
        }

        // Helper methods to get dropdown data

    }
}
