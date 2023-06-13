using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ValidationTask.Models;

namespace ValidationTask.Controllers{
  public class EmployeeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("EmployeeDetails",employee);
            }

            // Model state is not valid, return the view with validation errors
            return View(employee);
        }


        public ActionResult EmployeeDetails(Employee employee)
        {
            return View(employee);
        }

        [HttpPost]
        public JsonResult ValidateDateOfJoining(DateTime dateOfJoining, DateTime dateOfBirth)
        {
            if (dateOfJoining < dateOfBirth)
            {
                return Json("Invalid date of joining. It should be after the date of birth.");
            }

            return Json(true);
        }


    }
}