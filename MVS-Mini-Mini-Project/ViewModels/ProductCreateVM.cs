using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.ViewModels
{
    public class ProductCreateVM
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<BanType> BanTypes { get; set; }
    }
}
