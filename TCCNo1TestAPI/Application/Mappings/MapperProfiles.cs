using AutoMapper;

namespace TCCNo1TestAPI.Application.Mappings
{
    public static class MapperProfiles
    {
        public static void AddMapperProfiles(this  IMapperConfigurationExpression mapper)
        {
            mapper.AddProfiles([
                new PersonProfile()
            ]);
        }
    }
}
