using CleanArchitecture.API.DIs;
using CleanArchitecture.API.Extensions;
using CleanArchitecture.API.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ModelToDtoProfile), typeof(DtoToModelProfile));
builder.Services.ConfigureSqlContext();
builder.Services.ConfigureToBindDependencies();
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();

var app = builder.Build();

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();