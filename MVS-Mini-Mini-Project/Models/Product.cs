﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MVS_Mini_Mini_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SortDesc { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public List<ProductImage> Images { get; set; }
        [NotMapped]
        public List<IFormFile> UploadedImages { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public int? BanTypeId { get; set; }
        public BanType BanType { get; set; }
    }
}
