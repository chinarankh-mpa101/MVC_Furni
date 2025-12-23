using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furni101.App.Areas.admin.Controllers
{

    [Area("Admin")]
    public class ProductController(FurniDbContext _context) : Controller
    {
 
        public async Task<IActionResult> Index()
        {
            var features = await _context.Products.ToListAsync();

            return View(features);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Product feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Products.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var feature = await _context.Products.FindAsync(id);
            if (feature is null)
                return NotFound();
            _context.Products.Remove(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
