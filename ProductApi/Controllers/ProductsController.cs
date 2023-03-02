using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_productsCollection.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productsCollection.GetProduct(id);

            if (product is null)
                return NotFound();

            return Ok(product);
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
        public ActionResult CreateProduct(Product product)
        {
            _productsCollection.AddProduct(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product product)
        {
            var exsitingProduct = _productsCollection.GetProduct(id);
            if (exsitingProduct is null)
                return NotFound();

            _productsCollection.UpdateProduct(id, product);

            return NoContent();
        }
    }
}