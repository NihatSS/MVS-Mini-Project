using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly AppDbContext _context;

        public DiscountController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Discounts.OrderByDescending(x=>x.Id).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Discount discount = await _context.Discounts.FirstOrDefaultAsync(m => m.Id == id);

            if (discount is null) return NotFound();

            return View(discount);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool hasDiscount = await _context.Discounts.AnyAsync(m => m.Name.Trim() == discount.Name.Trim());

            if (hasDiscount)
            {
                ModelState.AddModelError("Name", "Discount already exist");
                return View();
            }

            if (discount.DiscountPercent > 100 || discount.DiscountPercent < 0)
            {
                ModelState.AddModelError("DiscountPercent", "Invalid discount percent");
                return View();
            }

            await _context.Discounts.AddAsync(new Discount { Name = discount.Name , DiscountPercent = discount.DiscountPercent});
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == id);

            if (discount == null) return NotFound();
            _context.Discounts.Remove(discount);
            foreach (var item in _context.Products.Where(x => x.Discount.Name == discount.Name))
            {
                item.Discount = new Discount { Name = "None", DiscountPercent = 0};
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Discount discount = await _context.Discounts.FirstOrDefaultAsync(m => m.Id == id);

            if (discount is null) return NotFound();

            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Discount discount)
        {
            if (id is null) return BadRequest();

            Discount existDiscount = await _context.Discounts.FirstOrDefaultAsync(m => m.Id == id);

            if (existDiscount is null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool hasDiscount = await _context.Discounts.AnyAsync(m => m.Name.Trim() == discount.Name.Trim() && m.Id != id);

            if (hasDiscount)
            {
                ModelState.AddModelError("Name", "Discount already exist");
                return View();
            }

            if (discount.DiscountPercent > 100 || discount.DiscountPercent < 0) 
            {
                ModelState.AddModelError("DiscountPercent", "Invalid discount percent");
                return View();
            }

            existDiscount.Name = discount.Name;
            existDiscount.DiscountPercent = discount.DiscountPercent;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
