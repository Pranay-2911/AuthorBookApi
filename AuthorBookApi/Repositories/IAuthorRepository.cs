using AuthorBookApi.Models;

namespace AuthorBookApi.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAll();
        public Author GetAuthor(int id);
        public int Add(Author author);
        public Author Update(Author author);
        public int Delete(Author author); 
    }
}
