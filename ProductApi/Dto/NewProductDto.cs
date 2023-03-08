using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class NewProductDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public TypeOfProduct Type { get; set; }
        [Required]
        [Range(1, Double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(0, 99.9)]
        public double Discount { get; set; }
    }
}
