using AssestmenNowOptics.DataAccess;
using AssestmenNowOptics.Models;
using AssestmenNowOptics.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssestmenNowOptics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreProductMappingController : ControllerBase
    {
        private readonly IStoreProductMappingRepository _repository;

        public StoreProductMappingController(IStoreProductMappingRepository repository)
        {
            _repository = repository;
        }



        // GET: api/<StoreProductMappingController>
        [HttpGet]
        public IEnumerable<StoreProductMapping> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<StoreProductMappingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mapping = _repository.GetStoreProductMapping(id);
            return Ok(mapping) ?? StatusCode(204, "The requested mapping doesn't exist");
        }

        // POST api/<StoreProductMappingController>
        [HttpPost]
        public IActionResult Post([FromBody] StoreProductMappingRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var mapping = new StoreProductMapping
                {
                    ProductId = request.ProductId,
                    StoreId = request.StoreId,
                    Stock = request.Stock,
                };
                _repository.Add(mapping);
                return Ok(mapping);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<StoreProductMappingController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoreProductMappingRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var mapping = _repository.GetStoreProductMapping(id);
                if(mapping == null)
                {
                    return StatusCode(204, "The requested product doesn't exist");
                }
                mapping.StoreId = request.StoreId;
                mapping.Stock = request.Stock;
                mapping.ProductId = request.ProductId;
                _repository.Update(mapping);
                return Ok(mapping);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<StoreProductMappingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("Mapping deleted");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
