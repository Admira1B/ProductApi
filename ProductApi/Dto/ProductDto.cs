using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class ProductDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public double Price { get; init; }
        public double Discount { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
