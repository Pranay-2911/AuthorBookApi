using AuthorBookApi.Data;
using AuthorBookApi.Models;

namespace AuthorBookApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AuthorContext _context;

        public BookRepository(AuthorContext authorContext)
        {
            _context = authorContext;
        }
        public int Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return 1;
        }

        public int Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return 1;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(a => a.Id == id);
        }

        public Book Update(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
            return book;
        }
    }
}
