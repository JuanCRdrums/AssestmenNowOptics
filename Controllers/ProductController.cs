using AssestmenNowOptics.DataAccess;
using AssestmenNowOptics.Models;
using AssestmenNowOptics.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssestmenNowOptics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProduct(id);
            return Ok(product) ?? StatusCode(204, "The requested product doesn't exist");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductRequest request)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = new Product { ProductName = request.ProductName };
                _productRepository.Add(product);
                return Ok(product);

            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = _productRepository.GetProduct(id);
                if(product == null)
                {
                    return StatusCode(204, "The requested product doesn't exist");
                }
                product.ProductName = request.ProductName;
                _productRepository.Update(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.Delete(id);
                return Ok("Product deleted");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
