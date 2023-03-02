using Microsoft.AspNetCore.Mvc;
using ProductApi.Dto;
using ProductApi.Service;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        IProductService _productsCollection;
        public ProductsController(IProductService products) { _productsCollection = products; }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            return Ok((await _productsCollection.GetProducts()).Select(product => product.AsProductDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productsCollection.GetProduct(id);

            if (product is null)
                return NotFound();

            return Ok(product.AsProductDto());
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

        [HttpPost]
        public async Task<ActionResult> CreateProduct(NewProductDto productDto)
        {
            Product product = new()
            {
                Id = _productsCollection.GetNewId(),
                Name = productDto.Name,
                Type = productDto.Type,
                Price = productDto.Price,
                Discount= productDto.Discount,
                TotalPrice = productDto.Price - (productDto.Price * productDto.Discount/100),
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _productsCollection.AddProduct(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, UpdateProductDto productDto)
        {
            var exsitingProduct = await _productsCollection.GetProduct(id);
            if (exsitingProduct is null)
                return NotFound();

            var updatedProduct = exsitingProduct with 
            {
                Name = productDto.Name,
                Type = productDto.Type,
                Price = productDto.Discount,
                Discount = productDto.Discount,
                TotalPrice = productDto.Price - (productDto.Price * productDto.Discount / 100)
            };

            await _productsCollection.UpdateProduct(id, updatedProduct);

            return Ok(updatedProduct.AsProductDto());
        }
    }
}