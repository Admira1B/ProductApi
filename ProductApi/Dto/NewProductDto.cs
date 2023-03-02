﻿using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class NewProductDto
    {
        [Required]
        public string? Name { get; init; }
        [Required]
        [Range(1, Double.MaxValue)]
        public double Price { get; init; }
        [Required]
        [Range(0, 99.9)]
        public double Discount { get; init; }
    }
}
