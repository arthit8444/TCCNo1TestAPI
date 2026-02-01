using TCCNo1TestAPI.Application.DTOs;
using TCCNo1TestAPI.Application.Interfaces;
using TCCNo1TestAPI.Domain.Entities;
using TCCNo1TestAPI.Domain.Interfaces;

namespace TCCNo1TestAPI.Presentation.API
{
    public static class PersonEndpoint
    {
        public static RouteGroupBuilder MapPersonEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Person").WithTags(nameof(Person));
            group.MapGet("/", () =>
            {
                return Results.Ok("Person API is running.");
            })
            .WithName("GetPersonStatus");

            group.MapGet("/All", async (IPersonInfoService service) =>
            {
                try
                {
                    var result = await service.GetAllPerson();

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex);
                }
            });

            group.MapPost("/Person", async (IPersonInfoService service, PersonDto dto) =>
            {
                try
                {
                    await service.CreatePerson(dto);
                    return Results.Ok("Create Person Success");
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex);
                }
            });

            group.MapGet("/{id}", async (IPersonInfoService service, int id) =>
            {
                try
                {
                    var result = await service.GetPersonById(id);

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex);
                }
            });

            return group;
        }
    }
}
