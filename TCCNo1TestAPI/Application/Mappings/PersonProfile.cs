using AutoMapper;
using TCCNo1TestAPI.Application.DTOs;
using TCCNo1TestAPI.Domain.Entities;

namespace TCCNo1TestAPI.Application.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
