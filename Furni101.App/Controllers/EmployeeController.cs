using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furni101.App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly FurniDbContext _context;
        public EmployeeController(FurniDbContext Context)
        {
            _context = Context; 
        }

        public IActionResult Index()
        {

            List<Employee> emps = _context.Employees.ToList();
          
            return View(emps);

        }
    }
}
