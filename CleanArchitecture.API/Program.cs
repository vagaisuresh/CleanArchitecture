using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, IRoleRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, IUserRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
