using Furni.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Furni.App.Contexts
{
    public class FurniDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public FurniDbContext(DbContextOptions<FurniDbContext> options) :base(options)
        {
            
        }
    }
}
