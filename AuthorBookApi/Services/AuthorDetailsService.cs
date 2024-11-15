using AuthorBookApi.DTOs;
using AuthorBookApi.Models;
using AuthorBookApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Services
{
    public class AuthorDetailsService :IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetail> _repository1;
        private readonly IRepository<Author> _authorRepository; //faltu

        private readonly IMapper _mapper;
        public AuthorDetailsService(IRepository<AuthorDetail> detailRepository, IMapper mapper)
        {
            _repository1 = detailRepository;
            _mapper = mapper;
        }
        public int AddAuthorDetails(AuthorDetailsDTO detailDTO)
        {
            var detail = _mapper.Map<AuthorDetail>(detailDTO);
            _repository1.Add(detail);
            return detail.Id;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var detail = _repository1.Get(id);
            if (detail != null)
            {
                _repository1.Delete(detail);
                return true;
            }
            return false;
        }

        public List<AuthorDetailsDTO> GetAuthorsDetails()
        {
            var details = _repository1.GetAll().ToList();
            List<AuthorDetailsDTO> detailDTO = _mapper.Map<List<AuthorDetailsDTO>>(details);
            return detailDTO;
        }

        public AuthorDetailsDTO GetById(int id)
        {
            var details = _repository1.Get(id);
            AuthorDetailsDTO detailDTO = _mapper.Map<AuthorDetailsDTO>(details);
            return detailDTO;
        }

        public bool UpdateAuthorDetails(AuthorDetailsDTO detailDTO)
        {
            var detail = _mapper.Map<AuthorDetail>(detailDTO);
            var existingdetail = _repository1.GetAll().AsNoTracking().FirstOrDefault(a => a.Id == detail.Id);
            if (existingdetail != null)
            {
                _repository1.Update(detail);
                return true;
            }
            return false;
        }

        public AuthorDetailsDTO GetByAuthorId(int id)
        {
            var authorDetails = _repository1.GetAll().Include(a => a.Author).ToList();
            var author = authorDetails.Where(a => a.AuthorId == id).FirstOrDefault();
            AuthorDetailsDTO authorDetail = _mapper.Map<AuthorDetailsDTO>(author);
            return authorDetail;
        }

    }
}
