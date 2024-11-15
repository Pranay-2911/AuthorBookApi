using AuthorBookApi.DTOs;
using AuthorBookApi.Models;

namespace AuthorBookApi.Services
{
    public interface IBookService
    {
        public List<BookDTO> GetBooks();
        public BookDTO GetById(int id);
        public int AddBook(BookDTO bookDTO);
        public bool DeleteBook(int id);
        public bool UpdateBook(BookDTO bookDTO);
        public BookDTO GetBookByAuthorID(int id);
    }
}
