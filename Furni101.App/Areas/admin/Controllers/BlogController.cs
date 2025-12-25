using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furni101.App.Areas.admin.Controllers
{
    [Area("Admin")]
    public class BlogController(FurniDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.Include(x=>x.Employee).ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Create()
        {
            var employees = await _context.Employees.ToListAsync();
            ViewBag.Employees = employees;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {


            if (!ModelState.IsValid)
            {
                var employees = await _context.Employees.ToListAsync();
                ViewBag.Categories = employees;
                return View();
            }
            var isExistEmployee = await _context.Employees.AnyAsync(c => c.Id == blog.EmployeeId);
            if (!isExistEmployee)
            {
                var employees = await _context.Employees.ToListAsync();
                ViewBag.Employees = employees;
                ModelState.AddModelError("CategoryId", "Bele bir category movcud deyil");
                return View(blog);
            }
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
