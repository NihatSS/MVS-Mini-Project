using System.ComponentModel.DataAnnotations;

namespace MVS_Mini_Mini_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
