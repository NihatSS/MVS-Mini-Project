using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.ViewModels;

namespace MVS_Mini_Mini_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(new BlogVM()
            {
                Categories = await _context.Categories.ToListAsync(),
                News = await _context.News.OrderByDescending(x=>x.Id).Take(3).ToListAsync(),
            });
        }
    }
}
