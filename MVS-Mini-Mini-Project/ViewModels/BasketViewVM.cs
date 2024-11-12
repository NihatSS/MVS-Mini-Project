using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.ViewModels
{
    public class BasketViewVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ProductCount { get; set; }
        public decimal Total { get; set; }
    }
}
