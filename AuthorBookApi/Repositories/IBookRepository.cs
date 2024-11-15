using AuthorBookApi.Models;

namespace AuthorBookApi.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book GetBook(int id);
        public int Add(Book book);
        public Book Update(Book book);
        public int Delete(Book book);
    }
}
