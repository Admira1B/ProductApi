using ProductApi.Dto;

namespace ProductApi
{
    public static class Extencions
    {
        public static ProductDto AsProductDto(this Product product)
        {
            return new ProductDto()
            {
                Id= product.Id,
                Name= product.Name,
                Price= product.Price,
                Discount= product.Discount,
                CreatedDate = product.CreatedDate
            };
        }
    }
}
