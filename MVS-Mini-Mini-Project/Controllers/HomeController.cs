using Microsoft.AspNetCore.Mvc;

namespace MVS_Mini_Mini_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
