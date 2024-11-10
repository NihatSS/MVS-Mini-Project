using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Data;
using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public NewsController(AppDbContext context,
                              IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            News news = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (news is null) return NotFound();

            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + request.Photo.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/img", fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.Photo.CopyToAsync(stream);
            }

            await _context.News.AddAsync(new News 
            { 
                Image = fileName,
                Title = request.Title,
                Desc = request.Desc,
            });

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var news = await _context.News.FindAsync(id);

            string existPath = Path.Combine(_env.WebRootPath, "assets/img", news.Image);

            DeleteFile(existPath);

            _context.News.Remove(news);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        private void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
