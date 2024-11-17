using AuthorBookApi.Data;
using AuthorBookApi.DTOs;
using AuthorBookApi.Exceptions;
using AuthorBookApi.Models;
using AuthorBookApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Services
{
    public class AuthorService :IAuthorService
    {
        private readonly IRepository<Author> _repository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper, IRepository<Book> bookRepository)
        {
            _repository = authorRepository;  
            _bookRepository = bookRepository;
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
            throw new AuthorNotFoundException("No such Author Exist");
        }

        public List<AuthorDTO> GetAuthors()
        {
            var authors =  _repository.GetAll().Include(a => a.Books).Include(a => a.AuthorDetail).ToList();
            if(authors.Count == 0)
            {
                throw new AuthorNotFoundException("No such Author Exist");
            }
            List<AuthorDTO> authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);
            return authorDTOs;
              
        }

        public AuthorDTO GetById(int id)
        {
            var author = _repository.Get(id);
            if (author == null)
            {
                throw new AuthorNotFoundException("No such Author Exist");
            }
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
            throw new AuthorNotFoundException("No such Author Exist");
        }
        public AuthorDTO GetByName(string name)
        {
            var author = _repository.GetAll().Where(a => a.Name == name).FirstOrDefault();
            if (author == null)
            {
                throw new AuthorNotFoundException("No such Author Exist");
            }
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public AuthorDTO GetAuthorByBookID(int id)
        {
            var book = _bookRepository.Get(id);
            if(book == null)
            {
                throw new BookNotFoundException("No such Book Exist");
            }
            var author = _repository.Get(book.AuthorId);
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }



    }
}
