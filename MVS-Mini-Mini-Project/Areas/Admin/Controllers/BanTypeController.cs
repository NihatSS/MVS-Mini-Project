using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class BanTypeController : Controller
    {
        private readonly AppDbContext _context;

        public BanTypeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.BanTypes.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BanType type)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.BanTypes.AddAsync(type);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            BanType type = await _context.BanTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (type is null) return NotFound();

            return View(type);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            BanType type = await _context.BanTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (type is null) return NotFound();

            return View(type);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BanType request)
        {
            if (id is null) return BadRequest();

            BanType type = await _context.BanTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (type is null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            type.Name = request.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var type = await _context.BanTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (type == null) return NotFound();
            _context.BanTypes.Remove(type);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
