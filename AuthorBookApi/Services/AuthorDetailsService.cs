using AuthorBookApi.DTOs;
using AuthorBookApi.Exceptions;
using AuthorBookApi.Models;
using AuthorBookApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApi.Services
{
    public class AuthorDetailsService :IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetail> _repository;

        private readonly IMapper _mapper;
        public AuthorDetailsService(IRepository<AuthorDetail> detailRepository, IMapper mapper)
        {
            _repository = detailRepository;
            _mapper = mapper;
        }
        public int AddAuthorDetails(AuthorDetailsDTO detailDTO)
        {
            var detail = _mapper.Map<AuthorDetail>(detailDTO);
            _repository.Add(detail);
            return detail.Id;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var detail = _repository.Get(id);
            if (detail != null)
            {
                _repository.Delete(detail);
                return true;
            }
            throw new AuthorDetailsNotFoundException("No Author Details Exist");
        }

        public List<AuthorDetailsDTO> GetAuthorsDetails()
        {
            var details = _repository.GetAll().ToList();
            if(details == null)
            {
                throw new AuthorDetailsNotFoundException("No Author Details Exist");
            }
            List<AuthorDetailsDTO> detailDTO = _mapper.Map<List<AuthorDetailsDTO>>(details);
            return detailDTO;
        }

        public AuthorDetailsDTO GetById(int id)
        {
            var details = _repository.Get(id);
            if (details == null)
            {
                throw new AuthorDetailsNotFoundException("No Author Details Exist");
            }
            AuthorDetailsDTO detailDTO = _mapper.Map<AuthorDetailsDTO>(details);
            return detailDTO;
        }

        public bool UpdateAuthorDetails(AuthorDetailsDTO detailDTO)
        {
            var detail = _mapper.Map<AuthorDetail>(detailDTO);
            var existingdetail = _repository.GetAll().AsNoTracking().FirstOrDefault(a => a.Id == detail.Id);
            if (existingdetail != null)
            {
                _repository.Update(detail);
                return true;
            }
            throw new AuthorDetailsNotFoundException("No Author Details Exist");
        }

        public AuthorDetailsDTO GetByAuthorId(int id)
        {
            var authorDetails = _repository.GetAll().Where(a => a.AuthorId == id).FirstOrDefault();
            if (authorDetails == null)
            {
                throw new AuthorDetailsNotFoundException("No Author Details Exist");
            }
            AuthorDetailsDTO authorDetailDTO = _mapper.Map<AuthorDetailsDTO>(authorDetails);
            return authorDetailDTO;

        }



    }
}


