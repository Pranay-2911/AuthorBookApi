using AuthorBookApi.DTOs;
using AuthorBookApi.Exceptions;
using AuthorBookApi.Models;
using AuthorBookApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _repository = bookRepository;
            _mapper = mapper;
        }
        public int AddBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _repository.Add(book);
            return book.Id;
        }

        public bool DeleteBook(int id)
        {
            var book = _repository.Get(id); GetById(id);
            if (book != null)
            {
                _repository.Delete(book);
                return true;
            }
            throw new BookNotFoundException("No Such Book Exist");
        }

        public List<BookDTO> GetBooks()
        {
            var books =  _repository.GetAll().ToList();
            if(books.Count == 0)
            {
                throw new BookNotFoundException("No Such Book Exist");
            }
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;    

        }

        public BookDTO GetById(int id)
        {
            var book = _repository.Get(id);
            if (book == null)
            {
                throw new BookNotFoundException("No Such Book Exist");
            }
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public bool UpdateBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            var existingBook = _repository.GetAll().AsNoTracking().FirstOrDefault(a => a.Id == book.Id);
            if (existingBook != null)
            {
                _repository.Update(book);
                return true;
            }
            throw new BookNotFoundException("No Such Book Exist");
        }

        public List<BookDTO> GetBookByAuthorID(int id)
        {
            var book = _repository.GetAll().Where(a=> a.AuthorId == id).ToList();
            if (book == null)
            {
                throw new BookNotFoundException("No Such Book Exist");
            }
            List<BookDTO> bookDTO = _mapper.Map<List<BookDTO>>(book);
            return bookDTO;
        }


    }
}
