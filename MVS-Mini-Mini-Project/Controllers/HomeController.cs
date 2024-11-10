using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;
using MVS_Mini_Mini_Project.ViewModels;

namespace MVS_Mini_Mini_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new HomeVM()
            {
                SliderImages = await _context.SliderImages.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Banners = await _context.Banners.OrderByDescending(x=>x.Id).ToListAsync(),
            });
        }
    }
}
