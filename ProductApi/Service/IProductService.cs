
namespace ProductApi.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void RemoveProduct(int id);
        void UpdateProduct(int id, Product required);
        int GetNewId();

    }
}
