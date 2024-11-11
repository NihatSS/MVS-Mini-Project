using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVS_Mini_Mini_Project.ViewModels
{
    public class SliderImageEditVM
    {
        public int Id { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
