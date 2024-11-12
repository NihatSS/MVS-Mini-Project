using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;
using MVS_Mini_Mini_Project.ViewModels;
using Newtonsoft.Json;

namespace MVS_Mini_Mini_Project.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public BasketController(AppDbContext context, 
                                IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
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

            List<BasketViewVM> basketDetails = new();

            foreach (var item in basket)
            {
                var product = await _context.Products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == item.ProductId);

                basketDetails.Add(new BasketViewVM
                {
                    Id = product.Id,
                    ProductCount = item.ProductCount,
                    Name = product.Name,
                    Image = product.Images.FirstOrDefault(m => m.IsMain).Image,
                    Total = item.ProductCount * product.Price,
                });
            }

            return View(basketDetails);
        }

        public async Task<IActionResult> DeleteWorkFromBasket(int id)
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

            var removeData = basket.FirstOrDefault(x => x.ProductId == id);

            basket.Remove(removeData);

            _httpContext.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DecreaseWorkInBasket(int id)
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

            var product = basket.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                if (product.ProductCount > 1)
                {
                    product.ProductCount--;
                }
            }
            _httpContext.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> IncreaseWorkInBasket(int id)
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

            var product = basket.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                product.ProductCount++;
            }
            _httpContext.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return RedirectToAction(nameof(Index));
        }
    }
}
