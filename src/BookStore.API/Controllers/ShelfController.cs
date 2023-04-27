using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/shelves")]
    public class ShelfController : Controller
    {
        private readonly IShelfRepository _shelfRepository;

        public ShelfController(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        // GET api/shelves
        [HttpGet(Name ="GetAllShelvies")]
        public async Task< IActionResult> GetAll()
        {
            var shelves = await _shelfRepository.GetAll();
            return Ok(shelves);
        }

        // GET api/shelves/5
        [HttpGet("{id}",Name ="GetShelveById")]
        public async Task<IActionResult> GetById(int id)
        {
            var shelf = await _shelfRepository.GetById(id);

            if (shelf == null)
            {
                return NotFound();
            }

            return Ok(shelf);
        }

        // POST api/shelves
        [HttpPost(Name ="AddShelves")]
        public IActionResult Add([FromBody] Shelf shelf)
        {
            if (shelf == null)
            {
                return BadRequest();
            }

            _shelfRepository.Add(shelf);

            return CreatedAtRoute("GetShelveById", new { id = shelf.Id }, shelf);
        }

        // PUT api/shelves/5
        [HttpPut("{id}",Name ="UpdateShelve")]
        public async Task< IActionResult> Update(int id, [FromBody] Shelf shelf)
        {
            if (shelf == null || shelf.Id != id)
            {
                return BadRequest();
            }

            var existingShelf = await _shelfRepository.GetById(id);

            if (existingShelf == null)
            {
                return NotFound();
            }

            existingShelf.Id = shelf.Id;
            existingShelf.RackId = shelf.RackId;

            _shelfRepository.Update(existingShelf);

            return new NoContentResult();
        }

        // DELETE api/shelves/5
        [HttpDelete("{id}",Name ="DeleteShelf")]
        public async Task<IActionResult> Delete(int id)
        {
            var shelf = await _shelfRepository.GetById(id);

            if (shelf == null)
            {
                return NotFound();
            }

         await   _shelfRepository.Delete(shelf);

            return new NoContentResult();
        }
    }
}
