using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existProduct = await _context.Products.FindAsync(product.Id);
            if (existProduct is null)
            {
                return BadRequest();
            }

            existProduct.Name = product.Name;
            existProduct.Price = product.Price;
            existProduct.ImageName = product.ImageName;
            existProduct.IsDeleted = product.IsDeleted;
            existProduct.ImageUrl = product.ImageUrl;
            _context.Products.Update(existProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        
        public async Task<IActionResult> SoftDelete(int id)
        {

            var foundProduct = await _context.Products.FindAsync(id);

            if (foundProduct is null)
            {
                return NotFound();
            }
            foundProduct.IsDeleted = !foundProduct.IsDeleted;
            _context.Products.Update(foundProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }












    }
}
