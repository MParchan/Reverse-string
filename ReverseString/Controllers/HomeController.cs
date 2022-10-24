using Microsoft.AspNetCore.Mvc;
using ReverseString.Models;
using System.Diagnostics;

namespace ReverseString.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Index(string enteredString)
        {
            ViewData["Heading"] = "Reverse Word:";
            ViewData["ReverseWord"] = ReverseString(enteredString);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string ReverseString(string eneteredString)
        {
            if(eneteredString == null)
                return string.Empty;

            if(eneteredString.Length > 0)
                return eneteredString[eneteredString.Length-1] + ReverseString(eneteredString.Substring(0, eneteredString.Length-1));       
            else
                return eneteredString;

        }
    }
}