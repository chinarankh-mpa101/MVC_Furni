using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furni101.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly FurniDbContext _context;

        public ProductController(FurniDbContext Context)
        {
            _context = Context;
        }

        public IActionResult Index()
        {
            List<Product> features = _context.Products.ToList();
            //ViewBag.AppFeatures = features;
            return View(features);
        }
    }
}
