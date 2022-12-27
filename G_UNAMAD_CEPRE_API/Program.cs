using AutoMapper;
using G_UNAMAD_CEPRE_API.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddMvc();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

