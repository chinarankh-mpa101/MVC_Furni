using Furni101.App.Contexts;
using Furni101.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furni101.App.Controllers
{
    public class BlogController(FurniDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.ToList();
            return View(blogs);
        }
    }
}
