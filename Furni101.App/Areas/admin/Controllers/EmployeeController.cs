using Furni101.App.Contexts;
using Furni101.App.Migrations;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Furni101.App.Areas.admin.Controllers
{

    [Area("Admin")]
    public class EmployeeController(FurniDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _context.Employees.AnyAsync(f => f.FirstName == employee.FirstName);
            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu title-da service movucuddur artiqqq!");
                return View();
            }


            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

             _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();

            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existEmployee= await _context.Employees.FindAsync(employee.Id);
            if (existEmployee == null)
            {
                return NotFound();
            }

            existEmployee.FirstName = employee.FirstName;
            existEmployee.LastName = employee.LastName;
            existEmployee.Position = employee.Position;
            existEmployee.Description = employee.Description;
            existEmployee.ImageUrl = employee.ImageUrl;
             _context.Employees.Update(existEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
