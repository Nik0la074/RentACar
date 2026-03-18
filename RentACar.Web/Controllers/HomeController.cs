using Microsoft.AspNetCore.Mvc;
using RentACar.Web.Models;
using System.Diagnostics;

namespace RentACar.Web.Controllers
{
    /// <summary>
    /// Handles the home page and general application navigation.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>Displays the home page.</summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>Displays the privacy policy page.</summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>Displays the error page.</summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}