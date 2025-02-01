using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.API.DIs
{
    public static class ServiceRegistrations
    {
        public static void ConfigureSqlContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("connectionString"));
        }
    }
}