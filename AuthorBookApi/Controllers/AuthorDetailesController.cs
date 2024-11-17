using AuthorBookApi.DTOs;
using AuthorBookApi.Models;
using AuthorBookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailesController : ControllerBase
    {
        private readonly IAuthorDetailsService _services;

        public AuthorDetailesController(IAuthorDetailsService service)
        {
            _services = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var detailsDTO = _services.GetAuthorsDetails();
            return Ok(detailsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var detailDTO = _services.GetById(id);
            return Ok(detailDTO);
        }

        [HttpPost]
        public IActionResult Add(AuthorDetailsDTO detail)
        {
           var id = _services.AddAuthorDetails(detail);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(AuthorDetailsDTO detail)
        {
            if (_services.UpdateAuthorDetails(detail))
            {
                return Ok(detail);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_services.DeleteAuthorDetails(id))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [HttpGet("author/{authorId}")] // 2nd Get AuthorDetails by Author Id
        public IActionResult GetByAuthorID(int authorId)
        {
            var detailDTO = _services.GetByAuthorId(authorId);
            return Ok(detailDTO);
        }
    }
}
