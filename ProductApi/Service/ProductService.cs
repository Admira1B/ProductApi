
namespace ProductApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductService(IMapper mapper, DataContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

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

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(int id, UpdateProductDto required)
        {
            var product = await _context.Products.FindAsync(id);

            product.Name = required.Name;
            product.Price = required.Price;
            product.Discount= required.Discount;
            product.Type = required.Type;
            product.TotalPrice = required.Price - (required.Price * required.Discount / 100);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}