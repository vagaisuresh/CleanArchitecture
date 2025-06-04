using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace CleanArchitecture.API.DIs
{
    public static class ServiceRegistrations
    {
        public static void ConfigureSqlContext(this IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("SqlConnection__CleanArchitecture") ?? string.Empty;

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Database connection string is not set in environment variables.");
            
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}