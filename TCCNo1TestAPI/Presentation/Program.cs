using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCCNo1TestAPI.Application.Interfaces;
using TCCNo1TestAPI.Application.Mappings;
using TCCNo1TestAPI.Domain.Context;
using TCCNo1TestAPI.Domain.Interfaces;
using TCCNo1TestAPI.Presentation.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi("v1");

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMapperProfiles();
});

builder.Services.AddDbContext<PersonContext>(options => options.UseSqlite("Data Source=person.db"));

builder.Services.Scan(scan => scan
    .FromAssembliesOf( 
        typeof(IPersonRepository),
        typeof(IPersonInfoService)
    )
    .AddClasses(classes => classes.InNamespaces([
        "TCCNo1TestAPI.Infrastructure.Repositories", 
        "TCCNo1TestAPI.Infrastructure.Services"
    ]))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddCors(option => {
    option.AddPolicy("AngularApp", cfg =>
    {
        cfg.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("AngularApp");

app.MapOpenApi();

app.MapGet("/", () => "TCC No.1 test");

app.MapPersonEndpoints();

app.Run();
