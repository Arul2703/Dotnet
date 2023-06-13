using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionException.Models;

namespace SessionException.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        // Simulating InvalidOperationException
        // Accessing session without configuring session middleware
        try
        {
            var value = HttpContext.Session.GetString("MySessionVariable");
            ViewBag.SessionValue = value;
        }
        catch (System.InvalidOperationException ex)
        {
            ViewBag.ErrorMessage = "An error occurred while accessing the session.";
            throw;
        }

        // Simulating NullReferenceException
        // Accessing a non-existent session variable
        try
        {
            string nonExistentVariable = HttpContext.Session.GetString("NonExistentVariable");
            ViewBag.SessionValue = nonExistentVariable;
        }
        catch (System.NullReferenceException ex)
        {
            ViewBag.ErrorMessage = "The requested session variable does not exist.";
           throw;
        }

        return View();
    }

    
}
