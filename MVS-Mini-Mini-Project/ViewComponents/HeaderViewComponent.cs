using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.ViewModels;
using Newtonsoft.Json;

namespace MVS_Mini_Mini_Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public HeaderViewComponent(AppDbContext context, 
                                   IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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

            decimal sum = 0;

            var productIds = basket.Select(b => b.ProductId).ToList();
            var products = await _context.Products
                                        .Where(p => productIds.Contains(p.Id))
                                        .Include(p => p.Discount)
                                        .ToListAsync();

            foreach (var item in basket)
            {
                var exisProduct = products.FirstOrDefault(x => x.Id == item.ProductId);
                if (exisProduct != null)
                {
                    var discount = exisProduct.Discount?.DiscountPercent ?? 0;
                    sum += (Convert.ToDecimal(exisProduct.Price) * (1 - (discount / 100m))) * item.ProductCount;
                }
            }

            return View(new HeaderVM
            {
                Categories = await _context.Categories.ToListAsync(),
                BasketCount = basket.Sum(m => m.ProductCount),
                TotalPrice = sum,
            });
        }




    }
}
