using AutoMapper;
using TCCNo1TestAPI.Application.DTOs;
using TCCNo1TestAPI.Application.Interfaces;
using TCCNo1TestAPI.Domain.Entities;
using TCCNo1TestAPI.Domain.Interfaces;

namespace TCCNo1TestAPI.Infrastructure.Services
{
    public class PersonInfoService(IPersonRepository person, IMapper mapper) : IPersonInfoService
    {
        private readonly IPersonRepository person = person;
        private readonly IMapper mapper = mapper;

        public async Task CreatePerson(PersonDto dto)
        {
            try
            {
                var entity = mapper.Map<PersonDto, Person>(dto);
                await person.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<PersonDto>> GetAllPerson()
        {
            var dtos = new List<PersonDto>();
            try
            {
                var entities = await person.GetAllAsync();
                if (entities != null && entities.Count > 0)
                {
                    dtos = mapper.Map<List<Person>, List<PersonDto>>(entities);
                }

                return dtos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            PersonDto dto = null;
            try
            {
                var entity = await person.GetByIdAsync(id);
                if (entity != null)
                {
                    dto = mapper.Map<Person, PersonDto>(entity);
                }
                
                return dto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
