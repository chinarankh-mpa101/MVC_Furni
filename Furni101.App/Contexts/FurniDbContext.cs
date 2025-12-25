using Furni101.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Furni101.App.Contexts
{
    public class FurniDbContext:DbContext
    {
        public DbSet<Product > Products { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public FurniDbContext(DbContextOptions<FurniDbContext> options ):base(options)
        {
            
        }
    }
}
