using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;
using MVS_Mini_Mini_Project.ViewModels;
using Newtonsoft.Json;

namespace MVS_Mini_Mini_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(AppDbContext context,
                              IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new HomeVM()
            {
                SliderImages = await _context.SliderImages.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Banners = await _context.Banners.OrderByDescending(x => x.Id).ToListAsync(),
                Brands = await _context.Brands.Take(12).ToListAsync(),
                News = await _context.News.ToListAsync(),
                Products = await _context.Products.Include(x => x.Category)
                                               .Include(x => x.Images)
                                               .Include(x => x.Discount)
                                               .Include(x => x.BanType)
                                               .OrderByDescending(x => x.Id)
                                               .ToListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBusket(int id)
        {
            List<BasketVM> basket;

            if (_httpContext.HttpContext.Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(_httpContext.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }

            var existBasketData = basket.FirstOrDefault(x => x.ProductId == id);

            if (existBasketData is null)
            {
                basket.Add(new BasketVM
                {
                    ProductId = id,
                    ProductCount = 1
                });
            }
            else
            {
                existBasketData.ProductCount++;
            }

            _httpContext.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return Ok(basket.Sum(x=>x.ProductCount));
        }

    }
}
