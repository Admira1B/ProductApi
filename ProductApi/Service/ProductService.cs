namespace ProductApi.Service
{
    public class ProductService : IProductService
    {
        List<Product> _products = new()
        {
            new Product { Id = 1,
                Name = "Apple",
                Price = 25,
                Discount = 5,
                CreatedDate = DateTimeOffset.UtcNow },
            new Product { Id = 2,
                Name = "Cheese",
                Price = 90,
                Discount = 0,
                CreatedDate = DateTimeOffset.UtcNow },
        };

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product GetProduct(int id)
        {
            Product? product = _products.Where(exsitingProduct => exsitingProduct.Id == id).SingleOrDefault();
            return product;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void RemoveProduct(int id)
        {
            var index = _products.FindIndex(product => product.Id == id);
            _products.RemoveAt(index);
        }

        public void UpdateProduct(int id, Product required)
        {
            var index = _products.FindIndex(product => product.Id == id);
            _products[index] = _products[index] with
            {
                Name = required.Name,
                Price = required.Price,
                Discount = required.Discount
            };
        }

        public int GetNewId()
        {
            return _products.Count + 1;
        }
    }
}
