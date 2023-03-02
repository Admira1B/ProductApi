namespace ProductApi.Service
{
    public class ProductService : IProductService
    {
        List<Product> _products = new();

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
        }

        public async Task<Product> GetProduct(int id)
        {
            Product? product = _products.Where(exsitingProduct => exsitingProduct.Id == id).SingleOrDefault();
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return _products;
        }

        public async Task RemoveProduct(int id)
        {
            var index = _products.FindIndex(product => product.Id == id);
            _products.RemoveAt(index);
        }

        public async Task UpdateProduct(int id, Product required)
        {
            var index = _products.FindIndex(product => product.Id == id);
            _products[index] = _products[index] with
            {
                Name = required.Name,
                Type = required.Type,
                Price = required.Price,
                Discount = required.Discount,
                TotalPrice = required.TotalPrice
            };
        }

        public int GetNewId()
        {
            return _products.Count + 1;
        }
    }
}
