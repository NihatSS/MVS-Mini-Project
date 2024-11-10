using MVS_Mini_Mini_Project.Models;

namespace MVS_Mini_Mini_Project.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Brand> Brands { get; set; }
        public List<SliderImage> SliderImages { get; set; }
        public List<Banner> Banners { get; set; }
        public List<News> News { get; set; }
    }
}
