using AuthorBookApi.DTOs;
using AuthorBookApi.Models;
using AuthorBookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _services;
        public AuthorController(IAuthorService authorService)
        {
            _services = authorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorsDTO = _services.GetAuthors();
            return Ok(authorsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var authorDTO = _services.GetById(id);
            return Ok(authorDTO);
        }

        [HttpPost]
        public IActionResult Add(AuthorDTO authorDTO)
        {
            var id = _services.AddAuthor(authorDTO);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(AuthorDTO authorDTO)
        {
            if (_services.UpdateAuthor(authorDTO))
            {
                return Ok(authorDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_services.DeleteAuthor(id))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [HttpGet("author/{name}")] // 1st find by author name
        public IActionResult GetByName(string name)
        {
            var authorDTO = _services.GetByName(name);
            return Ok(authorDTO);
        }

        [HttpGet("Book/{id}")]
        public IActionResult GetAuthorByBooks(int id) // 4th
        {
            var authorDto = _services.GetAuthorByBookID(id);
            return Ok(authorDto);
        }


        


    }
}
