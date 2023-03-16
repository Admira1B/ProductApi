using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productsCollection;
        public ProductsController(IProductService products) { _productsCollection = products; }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            return Ok(await _productsCollection.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productsCollection.GetProduct(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(NewProductDto newProductDto)
        {
            await _productsCollection.AddProduct(newProductDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, UpdateProductDto productDto)
        {
            var exsitingProduct = await _productsCollection.GetProduct(id);

            if (exsitingProduct is null)
                return NotFound();

            await _productsCollection.UpdateProduct(id, productDto);

            return Ok(await _productsCollection.GetProduct(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var exsitingProduct = await _productsCollection.GetProduct(id);

            if (exsitingProduct is null)
                return NotFound();

            await _productsCollection.RemoveProduct(id);

            return NoContent();
        }
    }
}