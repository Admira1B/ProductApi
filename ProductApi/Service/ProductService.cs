
namespace ProductApi.Service
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
            _products = new();

        }

        public async Task<ProductDto> GetProduct(int id)
        {
            Product? product = _products.Where(exsitingProduct => exsitingProduct.Id == id).SingleOrDefault();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
             return _products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
        }

        public async Task AddProduct(NewProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _products.Add(product);
        }

        public async Task UpdateProduct(int id, UpdateProductDto required)
        {
            var index = _products.FindIndex(product => product.Id == id);

            DateTimeOffset createdDate = _products[index].CreatedDate;
            _products[index] = _mapper.Map<Product>(required);

            _products[index].Id = id;
            _products[index].CreatedDate = createdDate;
        }

        public async Task RemoveProduct(int id)
        {
            var index = _products.FindIndex(product => product.Id == id);
            _products.RemoveAt(index);
        }

        public int GetNewId()
        {
            return _products.Count + 1;
        }
    }
}