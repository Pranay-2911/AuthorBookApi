using AuthorBookApi.DTOs;
using AuthorBookApi.Models;
using AuthorBookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _services;
        public BookController(IBookService bookService)
        {
            _services = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookDTO = _services.GetBooks();
            return Ok(bookDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bookDTO = _services.GetById(id);
            return Ok(bookDTO);
        }

        [HttpPost]
        public IActionResult Add(BookDTO bookDTO)
        {
            var id = _services.AddBook(bookDTO);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(BookDTO bookDTO)
        {
            if (_services.UpdateBook(bookDTO))
            {
                return Ok(bookDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_services.DeleteBook(id))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [HttpGet("author/{id}")] //3rd get book by author
        public IActionResult GetByAuthorID(int id)
        {
            var bookDTO = _services.GetBookByAuthorID(id);
            return Ok(bookDTO);
        }
    }
}
