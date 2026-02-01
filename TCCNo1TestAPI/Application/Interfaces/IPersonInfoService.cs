using TCCNo1TestAPI.Application.DTOs;

namespace TCCNo1TestAPI.Application.Interfaces
{
    public interface IPersonInfoService
    {
        Task<List<PersonDto>> GetAllPerson();
        Task<PersonDto> GetPersonById(int id);
        Task CreatePerson(PersonDto dto);
    }
}
