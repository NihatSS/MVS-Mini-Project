using System.ComponentModel.DataAnnotations;

namespace MVS_Mini_Mini_Project.Models
{
    public class BanType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
