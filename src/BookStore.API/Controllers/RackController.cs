using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/racks")]
    public class RackController : Controller
    {
        private readonly IRackRepository _rackRepository;

        public RackController(IRackRepository rackRepository)
        {
            _rackRepository = rackRepository;
        }

        // GET api/rackss
        [HttpGet(Name ="GetAllRacks")]
        public async Task<IActionResult> GetAll()
        {
            var racks =await _rackRepository.GetAll();
            return Ok(racks);
        }

        // GET api/racks/5
        [HttpGet("~/GetById/{id}", Name = "GetRackById")]
        public async Task<IActionResult> GetById(int id)
        {
            var rack = await _rackRepository.GetById(id);

            if (rack == null)
            {
                return NotFound();
            }

            return Ok(rack);
        }

        // POST api/racks
        [HttpPost(Name ="AddRack")]
        public IActionResult Add([FromBody] Rack rack)
        {
            if (rack == null)
            {
                return BadRequest();
            }

            _rackRepository.Add(rack);

            return CreatedAtRoute("GetById", new { id = rack.Id }, rack);
        }

        // PUT api/racks/5
        [HttpPut("Update/{id}",Name ="Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Rack rack)
        {
            if (rack == null || rack.Id != id)
            {
                return BadRequest();
            }

            var existingRack =await _rackRepository.GetById(id);

            if (existingRack == null)
            {
                return NotFound();
            }

            existingRack.Id = rack.Id;

            _rackRepository.Update(existingRack);

            return new NoContentResult();
        }

        // DELETE api/racks/5
        [HttpDelete("{id}",Name ="DeleteRack")]
        public async Task<IActionResult> Delete(int id)
        {
            var rack =await _rackRepository.GetById(id);

            if (rack == null)
            {
                return NotFound();
            }

            _rackRepository.Delete(rack);

            return new NoContentResult();
        }
    }
}
