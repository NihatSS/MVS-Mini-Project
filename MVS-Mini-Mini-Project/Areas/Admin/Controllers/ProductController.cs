using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;
using MVS_Mini_Mini_Project.ViewModels;
using NuGet.Packaging.Signing;

namespace MVS_Mini_Mini_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, 
                                 IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include(x=>x.Category)
                                               .Include(x=>x.Images)
                                               .Include(x=>x.Discount)
                                               .Include(x=>x.BanType)
                                               .Include(x=>x.Images)
                                               .ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _context.Products.Include(x=>x.Category)
                                                     .Include(x=>x.BanType)
                                                     .Include(x=>x.Discount)
                                                     .FirstOrDefaultAsync(m => m.Id == id);

            if (product is null) return NotFound();

            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new ProductCreateVM
            {
                Product = new Product(),
                Categories = await _context.Categories.ToListAsync(),
                BanTypes = await _context.BanTypes.ToListAsync(),
                Discounts = await _context.Discounts.ToListAsync(),
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool hasProduct = await _context.Products.AnyAsync(m => m.Name.Trim() == model.Product.Name.Trim());

            if (hasProduct)
            {
                ModelState.AddModelError("Product.Name", "Product with this name already exists");

                model.Categories = await _context.Categories.ToListAsync();
                model.BanTypes = await _context.BanTypes.ToListAsync();
                model.Discounts = await _context.Discounts.ToListAsync();

                return View(model);
            }

            var product = new Product
            {
                Name = model.Product.Name,
                SortDesc = string.Join(" ", model.Product.Desc.Split(' ').Take(7)),
                Desc = model.Product.Desc,
                Price = model.Product.Price,
                CategoryId = model.Product.CategoryId,
                DiscountId = model.Product.DiscountId,
                BanTypeId = model.Product.BanTypeId,
                Images = new List<ProductImage>(),
            };

            if (model.Product.UploadedImages != null && model.Product.UploadedImages.Count > 0)
            {
                for (int i = 0; i < model.Product.UploadedImages.Count; i++)
                {
                    var item = model.Product.UploadedImages[i];

                    if (item == null || item.Length == 0) continue;

                    string fileName = $"{Guid.NewGuid()}_{item.FileName}";
                    string path = Path.Combine(_env.WebRootPath, "assets/img", fileName);

                    using (FileStream stream = new(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    var productImage = new ProductImage
                    {
                        Image = fileName,
                        Product = product,
                        IsMain = (i == 0)
                    };

                    product.Images.Add(productImage);
                }
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
