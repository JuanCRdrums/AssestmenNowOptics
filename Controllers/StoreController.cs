using AssestmenNowOptics.DataAccess;
using AssestmenNowOptics.Models;
using AssestmenNowOptics.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssestmenNowOptics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }


        // GET: api/<StoreController>
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            return _storeRepository.GetAll();
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var store = _storeRepository.GetStore(id);
            return Ok(store) ?? StatusCode(204, "The requested store doesn't exist");
        }

        // POST api/<StoreController>
        [HttpPost]
        public IActionResult Post([FromBody] StoreRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var store = new Store { StoreName = request.StoreName };
                _storeRepository.Add(store);
                return Ok(store);

            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoreRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var store = _storeRepository.GetStore(id);
                if (store == null)
                {
                    return StatusCode(204, "The requested store doesn't exist");
                }
                store.StoreName = request.StoreName;
                _storeRepository.Update(store);
                return Ok(store);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _storeRepository.Delete(id);
                return Ok("Store deleted");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
