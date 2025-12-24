using Microsoft.AspNetCore.Mvc;

namespace Furni.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update() 
        {
            return View();
        }
    }
}
