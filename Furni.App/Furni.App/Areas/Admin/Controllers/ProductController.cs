using Furni.App.Contexts;
using Furni.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;

namespace Furni.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class ProductController(FurniDbContext context) : Controller
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
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var existModel = await context.Products.FindAsync(product.Id);

            if (existModel is null)
                return BadRequest();

            existModel.Name = product.Name;
            existModel.Price = product.Price;
            existModel.ImageName = product.ImageName;
            existModel.imageUrl = product.imageUrl;
            existModel.CreatedTime = product.CreatedTime;
            existModel.UpdatedTime = product.UpdatedTime;
            existModel.IsDeleted = product.IsDeleted;


            context.Products.Update(existModel);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product) 
        {
            if (!ModelState.IsValid) 
            {
                return View(product);
            }

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        { 
            var product = await context.Products.FindAsync(id);

            if (product is not { })
                return NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Toggle(int id) 
        {
            var product = await context.Products.FindAsync(id);
            if (product is not { })
                return NotFound();

            product.IsDeleted = !product.IsDeleted;
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
