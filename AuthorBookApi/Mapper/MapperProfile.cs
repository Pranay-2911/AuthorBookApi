using AuthorBookApi.DTOs;
using AuthorBookApi.Models;
using AutoMapper;

namespace AuthorBookApi.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDTO>().ForMember(dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));
            CreateMap<AuthorDTO, Author>();
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
            CreateMap<AuthorDetailsDTO, AuthorDetail>();
            CreateMap<AuthorDetail, AuthorDetailsDTO>();
        }
    }
}
