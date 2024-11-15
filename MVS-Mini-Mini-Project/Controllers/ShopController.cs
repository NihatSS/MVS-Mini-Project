using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.ViewModels;

namespace MVS_Mini_Mini_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(new ShopVM()
            {
                Products = await _context.Products.Include(x => x.Category)
                                               .Include(x => x.Images)
                                               .Include(x => x.Discount)
                                               .Include(x => x.BanType)
                                               .OrderByDescending(x => x.Id)
                                               .ToListAsync(),
                BanTypes = await _context.BanTypes.ToListAsync(),
            });
        }

        public async Task<IActionResult> Search(string searchText)
        {
            return View(new ShopVM()
            {
                Products = await _context.Products.Include(x => x.Category)
                                               .Include(x => x.Images)
                                               .Include(x => x.Discount)
                                               .Include(x => x.BanType)
                                               .OrderByDescending(x => x.Id)
                                               .ToListAsync(),
                BanTypes = await _context.BanTypes.ToListAsync(),
            });
        }
    }
}
