using AuthorBookApi.Data;
using AuthorBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorContext _context;

        public AuthorRepository(AuthorContext authorContext)
        {
            _context = authorContext;
        }
        public int Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return 1;
        }

        public int Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return 1;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Authors.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public Author Update(Author author)
        {
            _context.Update(author);
            _context.SaveChanges();
            return author;
        }
    }
}
