using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeVista2._0.Models;

namespace TimeVista2._0.Controllers
{
    public class tbl_employeeController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: tbl_employee
        public ActionResult Index()
        {
            var employees = db.tbl_employee.ToList();
            return View(employees);
        }

        // GET: tbl_employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // GET: tbl_employee/Create
        public ActionResult Create()
        {
            ViewBag.EmpId = GetNextEmployeeId(); // Get the next available employee ID
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList(); // Pass shifts for dropdown
            return View();
        }

        // POST: tbl_employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "first_name,last_name,username,emailid,password,dob,gender,employee_id,joining_date,phone,shift,department,status,created_at")] tbl_employee tbl_employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Set default values
                    tbl_employee.role = "0"; // Default role
                    tbl_employee.Lrty = 25; // Default Lrty
                    tbl_employee.password_reset = 0;
                    tbl_employee.status = 0;

                    // Set created_at date
                    tbl_employee.created_at = DateTime.Now;

                    // Add the employee to the database
                    db.tbl_employee.Add(tbl_employee);
                    db.SaveChanges();

                    // Redirect to the action to view all employees or any other page as needed
                    return RedirectToAction("Index"); // Redirect to the Index action to view all employees
                }
                catch (DbEntityValidationException ex)
                {
                    // Log the exception or inspect it to see validation errors
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }

                    // Optionally, handle the exception or provide user feedback
                    ModelState.AddModelError("", "Validation error occurred. Please check your input.");

                    // Reload the view with the model to display errors
                    ViewBag.EmpId = GetNextEmployeeId();
                    ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
                    ViewBag.Shifts = db.tbl_shift.ToList(); // Pass shifts for dropdown
                    return View(tbl_employee);
                }
            }

            // If ModelState is not valid, reload the view with errors
            ViewBag.EmpId = GetNextEmployeeId();
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList(); // Pass shifts for dropdown
            return View(tbl_employee);
        }

        // GET: tbl_employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList(); // Pass shifts for dropdown
            return View(tbl_employee);
        }

        // POST: tbl_employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,username,emailid,password,dob,gender,employee_id,joining_date,phone,shift,department,status,created_at")] tbl_employee tbl_employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Set default values
                    tbl_employee.role = "0"; // Default role
                    tbl_employee.Lrty = 25; // Default Lrty
                    tbl_employee.password_reset = 0; // Default password_reset

                    // Update the employee in the database
                    db.Entry(tbl_employee).State = EntityState.Modified;
                    db.SaveChanges();

                    // Redirect to the action to view all employees or any other page as needed
                    return RedirectToAction("Index"); // Redirect to the Index action to view all employees
                }
                catch (DbEntityValidationException ex)
                {
                    // Log the exception or inspect it to see validation errors
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }

                    // Optionally, handle the exception or provide user feedback
                    ModelState.AddModelError("", "Validation error occurred. Please check your input.");

                    // Reload the view with the model to display errors
                    ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
                    ViewBag.Shifts = db.tbl_shift.ToList(); // Pass shifts for dropdown
                    return View(tbl_employee);
                }
            }

            // If ModelState is not valid, reload the view with errors
            ViewBag.Departments = db.tbl_department.ToList(); // Pass departments for dropdown
            ViewBag.Shifts = db.tbl_shift.ToList(); // Pass shifts for dropdown
            return View(tbl_employee);
        }

        // GET: tbl_employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // POST: tbl_employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            db.tbl_employee.Remove(tbl_employee);
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

        // Helper method to get the next available employee ID for display
        private string GetNextEmployeeId()
        {
            return "EMP-" + (db.tbl_employee.Count() + 1).ToString("D3");
        }
    }
}
