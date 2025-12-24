using Furni101.App.Contexts;
using Microsoft.AspNetCore.Mvc;
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
    }
}
