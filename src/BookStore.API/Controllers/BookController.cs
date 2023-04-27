
using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.API.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET api/books
        [HttpGet(Name ="GetAllBooks")]
        public async Task< IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAll();
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}",Name ="GetBookById")]
        public IActionResult GetById(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/books
        [HttpPost(Name="AddBook")]
        public IActionResult Add([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _bookRepository.Add(book);

            return CreatedAtRoute("GetBookById", new { id = book.Id }, book);
        }

        // PUT api/books/5
        [HttpPut("{id}",Name = "UpdateBook")]
        public async Task<IActionResult> Update(int id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest();
            }

            var existingBook = await _bookRepository.GetById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Name = book.Name;
            existingBook.Author = book.Author;
            existingBook.IsAvailable = book.IsAvailable;
            existingBook.Price = book.Price;
            existingBook.ShelfId = book.ShelfId;

            _bookRepository.Update(existingBook);

            return new NoContentResult();
        }

        // DELETE api/books/5
        [HttpDelete("{id}",Name="DeleteBook")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Delete(book);

            return new NoContentResult();
        }
    }

}

