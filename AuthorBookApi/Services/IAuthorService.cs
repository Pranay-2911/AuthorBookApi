using AuthorBookApi.DTOs;
using AuthorBookApi.Models;

namespace AuthorBookApi.Services
{
    public interface IAuthorService
    {
        public List<AuthorDTO> GetAuthors();
        public AuthorDTO GetById(int id);
        public int AddAuthor(AuthorDTO author);
        public bool DeleteAuthor(int id);
        public bool UpdateAuthor(AuthorDTO authorDTO);
        public AuthorDTO GetByName(string name);



        public AuthorDTO GetAuthorByBookID(int id);

    }
}
