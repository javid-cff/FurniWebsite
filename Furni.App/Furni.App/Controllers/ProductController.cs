using Furni.App.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furni.App.Controllers
{
    public class ProductController : Controller
    {
        readonly FurniDbContext _context;

        public ProductController(FurniDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Where(c => c.IsDeleted).AsQueryable().ToListAsync();
            return View(products);
        }
    }
}
