using System;
using Microsoft.AspNetCore.Mvc;
using CookieException.Models;

namespace CookieException.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                Response.Cookies.Append("MyCookie", "CookieValue");

                string cookieValue = Request.Cookies["MyCookie"];

                if (!Request.Cookies.ContainsKey("CartCookie"))
                {
                    throw new InvalidOperationException("CartCookie does not exist.");
                }
                Response.Cookies.Append("CartCookie", "fooditems");

    
                if (!Request.Cookies.ContainsKey("NonExistentCookieToDelete"))
                {
                    throw new InvalidOperationException("NonExistentCookieToDelete does not exist.");
                }
                Response.Cookies.Delete("NonExistentCookieToDelete");

                if (string.IsNullOrEmpty("InvalidCookieName"))
                {
                    throw new ArgumentException("Invalid cookie name provided.");
                }
                Response.Cookies.Append("", "InvalidCookieName");

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred while working with cookies.");
                throw;
            }
        }
    }
}
