using System.ComponentModel.DataAnnotations.Schema;

namespace MVS_Mini_Mini_Project.Models
{
    public class SliderImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public List<IFormFile> Photo { get; set; }
    }
}
