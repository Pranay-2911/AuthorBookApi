using AuthorBookApi.Data;
using AuthorBookApi.DTOs;
using AuthorBookApi.Models;
using AuthorBookApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Services
{
    public class AuthorService :IAuthorService
    {
         private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _repository = authorRepository;  
            _mapper = mapper;
        }
        public int AddAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _repository.Add(author);
            return author.Id;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _repository.Get(id);
            if (author != null)
            {
                _repository.Delete(author);
                return true;
            }
            return false;
        }

        public List<AuthorDTO> GetAuthors()
        {
            var authors =  _repository.GetAll().Include(a => a.Books).Include(a => a.AuthorDetail).ToList();
            List<AuthorDTO> authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);
            return authorDTOs;
              
        }

        public AuthorDTO GetById(int id)
        {
            var author = _repository.Get(id);
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public bool UpdateAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            var existingAuthor = _repository.GetAll().AsNoTracking().FirstOrDefault(a=> a.Id == author.Id);
            if(existingAuthor != null)
            {
                _repository.Update(author);
                return true;
            }
            return false;
        }
        public AuthorDTO GetByName(string name)
        {
            var author = _repository.GetAll().Where(a => a.Name == name).FirstOrDefault();
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public AuthorDTO GetAuthorByBookID(int id)
        {
            var authors = _repository.GetAll().Include(a => a.Books).ToList();
            var author = authors.FirstOrDefault(a => a.Id == id);
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

    }
}
