using Furni101.App.Contexts;
using Furni101.App.Models;
using Furni101.App.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Furni101.App.Areas.admin.Controllers
{

    [Area("Admin")]
    public class ProductController(FurniDbContext _context, IWebHostEnvironment _enviroment) : Controller
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
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!vm.ImageUrl.ContentType.Contains("image"))
            {
                ModelState.AddModelError("ImageUrl", "Sekil formatinda daxil edin");
                return View(vm);
            }
            if (vm.ImageUrl.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageUrl", "seklin olcusu maximum 2mb ola biler");
            }


            string uniqueImageName= Guid.NewGuid().ToString() + vm.ImageUrl.FileName;
            string imageUrl = Path.Combine(_enviroment.WebRootPath, "assets", "images",uniqueImageName);

            using FileStream stream = new FileStream(imageUrl, FileMode.Create);
            await vm.ImageUrl.CopyToAsync(stream);

            Product product = new Product()
            {
                Name = vm.Name,
                Price = vm.Price,
                ImageName=vm.ImageName,
                ImageUrl= uniqueImageName,
            };           
            await _context.Products.AddAsync(product);
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

            string folderPath = Path.Combine(_enviroment.WebRootPath, "assets", "images");
            string mainImagePath = Path.Combine(folderPath, feature.ImageUrl);

            if (System.IO.File.Exists(mainImagePath))
            {
                System.IO.File.Delete(mainImagePath);
            }
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
