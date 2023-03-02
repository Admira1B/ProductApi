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
        public ActionResult<List<ProductDto>> GetProducts()
        {
            return Ok(_productsCollection.GetProducts().Select(product => product.AsProductDto()));
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var product = _productsCollection.GetProduct(id);

            if (product is null)
                return NotFound();

            return Ok(product.AsProductDto());
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var exsitingProduct = _productsCollection.GetProduct(id);

            if (exsitingProduct is null)
                return NotFound();

            _productsCollection.RemoveProduct(id);

            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateProduct(NewProductDto productDto)
        {
            Product product = new()
            {
                Id = _productsCollection.GetNewId(),
                Name = productDto.Name,
                Price = productDto.Price,
                Discount= productDto.Discount,
                CreatedDate = DateTimeOffset.UtcNow
            }; 

            _productsCollection.AddProduct(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, UpdateProductDto productDto)
        {
            var exsitingProduct = _productsCollection.GetProduct(id);
            if (exsitingProduct is null)
                return NotFound();

            var updatedProduct = exsitingProduct with { Name = productDto.Name, Price = productDto.Discount, Discount = productDto.Discount };

            _productsCollection.UpdateProduct(id, updatedProduct);

            return Ok(updatedProduct.AsProductDto());
        }
    }
}