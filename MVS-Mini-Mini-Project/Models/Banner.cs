using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVS_Mini_Mini_Project.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}
