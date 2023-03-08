namespace ProductApi.Service
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task AddProduct(NewProductDto productDto);
        Task RemoveProduct(int id);
        Task UpdateProduct(int id, UpdateProductDto required);
        int GetNewId();
    }
}