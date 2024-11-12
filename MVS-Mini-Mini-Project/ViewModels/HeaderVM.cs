using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.ViewModels
{
    public class HeaderVM
    {
        public List<Category> Categories { get; set; }
        public int BasketCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
