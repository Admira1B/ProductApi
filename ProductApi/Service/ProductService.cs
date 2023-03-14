
namespace ProductApi.Service
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductService(IMapper mapper, DataContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
            _products = new();

        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(exsitingProduct => exsitingProduct.Id == id);

            return _mapper.Map<ProductDto>(dbProduct);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var dbProducts = await _context.Products.ToListAsync();
             return dbProducts.Select(product => _mapper.Map<ProductDto>(product)).ToList();
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
    }
}