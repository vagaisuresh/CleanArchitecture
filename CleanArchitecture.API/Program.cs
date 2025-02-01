using CleanArchitecture.API.DIs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext();
builder.Services.ConfigureToBindDependencies();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
