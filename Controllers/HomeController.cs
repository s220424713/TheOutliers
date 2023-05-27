using Microsoft.AspNetCore.Mvc;
using Outliers_E_Commerce.Models;
using System.Diagnostics;
using Outliers_E_Commerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Outliers_E_Commerce.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDBContext _context;
        public HomeController(IWebHostEnvironment webHostEnvironment, ApplicationDBContext context
            , ILogger<HomeController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _logger = logger;
        }
    
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Ane()
        {
            return View();
        }
        public IActionResult CustDashboard()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DeptEmployee()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Sales()
        {
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
    }
}