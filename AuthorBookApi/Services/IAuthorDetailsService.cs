using AuthorBookApi.DTOs;
using AuthorBookApi.Models;

namespace AuthorBookApi.Services
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetailsDTO> GetAuthorsDetails();
        public AuthorDetailsDTO GetById(int id);
        public int AddAuthorDetails(AuthorDetailsDTO authorDetailDto);
        public bool DeleteAuthorDetails(int id);
        public bool UpdateAuthorDetails(AuthorDetailsDTO authorDetailDto);
        public AuthorDetailsDTO GetByAuthorId(int id);
    }
}
