using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/Book
        [HttpGet]
        [Route("/get")]
        public IActionResult Get()
        {
            List<Book> booksList = _bookRepository.GetAll();

            if (!booksList.Any())
                return NotFound();

            return Ok(booksList);
        }

        [HttpGet("{id}", Name = "get")]
        public IActionResult Get(string id)
        {
            Book book = _bookRepository.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("{avaliable}", Name = "getAvaliable")]
        public IActionResult GetAvaliable(bool avaliable)
        {
            List<Book> books = _bookRepository.GetAvaliable(avaliable);

            if (!books.Any())
                return NotFound();

            return Ok(books);
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book value)
        {
            Book book = _bookRepository.GetById(value.Id);
            if (book != null)
                return Conflict();

            _bookRepository.Insert(value);

            return Ok(value.Id);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Book value)
        {
            Book book = _bookRepository.GetById(id);

            if (book == null)
                return NotFound();

            _bookRepository.Update(value, id);

            return Ok(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Book book = _bookRepository.GetById(id);

            if (book == null)
                return NotFound();

            _bookRepository.RemoveById(id);

            return NoContent();
        }
    }
}
