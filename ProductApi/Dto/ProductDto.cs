using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public TypeOfProduct Type { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
