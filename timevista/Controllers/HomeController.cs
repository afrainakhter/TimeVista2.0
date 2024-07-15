using System.Linq;
using System.Web.Mvc;
using TimeVista2._0.Models;

namespace TimeVista2._0.Controllers
{
    public class HomeController : Controller
    {
        private Entities2 db = new Entities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        // Login GET action to display login view
       

        // Login POST action to perform login
        [HttpPost]
        public ActionResult PerformLogin(string username, string pwd)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
            {
                ViewBag.Message = "Please provide both username and password.";
                return View("Index");
            }

            // Fetch the user from the database
            var user = db.tbl_employee.FirstOrDefault(u => u.username == username && u.password == pwd);

            if (user != null)
            {
                // Set the user in session (or use any other method for authentication)
                Session["UserId"] = user.id;
                Session["Username"] = user.username;
                Session["Role"] = user.role;

                if (user.role == "1")
                {
                    // Admin role
                    return RedirectToAction("ADashboard", "Home");
                }
                else if (user.role == "0")
                {
                    // Employee role
                    return RedirectToAction("EmployeeDashboard", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid role.";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Message = "Invalid username or password.";
                return View("Index");
            }
        }

        // GET: Home/AdminDashboard
        public ActionResult ADashboard()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Home/EmployeeDashboard
        public ActionResult EmployeeDashboard()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "0")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult AttendaceFrom()
        {
            return View();

        }

        // Action to logout and redirect to index
        public ActionResult Logout()
        {
            // Clear session variables
            Session.Clear();

            // Redirect to index page
            return RedirectToAction("Index", "Home");
        }
    }
}
