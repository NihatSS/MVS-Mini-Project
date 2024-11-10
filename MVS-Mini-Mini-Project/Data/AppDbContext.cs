using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<News> News { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
