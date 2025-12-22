using System.Diagnostics;
using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furni101.App.Controllers
{
    public class HomeController : Controller
    {

        private readonly FurniDbContext _context;

        public HomeController(FurniDbContext Context)
        {
            _context = Context;

        }

        public IActionResult Index()
        {
            List<Product> features = _context.Products.ToList();
            //ViewBag.AppFeatures = features;
            return View(features);
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
