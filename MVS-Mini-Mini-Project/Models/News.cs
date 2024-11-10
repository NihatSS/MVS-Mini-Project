using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVS_Mini_Mini_Project.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
