
namespace ProductApi.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task RemoveProduct(int id);
        Task UpdateProduct(int id, Product required);
        Task<int> GetNewId();
    }
}
