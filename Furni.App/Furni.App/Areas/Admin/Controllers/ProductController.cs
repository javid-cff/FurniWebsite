using Furni.App.Contexts;
using Furni.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Furni.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(FurniDbContext context): Controller
    {
        public async Task<IActionResult> Index()
        {
            var products = await context.Products.ToListAsync();

            if (products is null)
                return NotFound();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id) 
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product model)
        {
            if (ModelState.IsValid)
                return View(model);

            context.Products.Update(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
