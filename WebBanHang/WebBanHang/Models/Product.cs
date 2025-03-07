﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        [DisplayName("Tên Sẩn phẩm")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
    
}
