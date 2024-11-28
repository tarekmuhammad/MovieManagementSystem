using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Infrastructure.Presistance.Data;
using MovieSystem.Infrastructure.Presistance.Repository;

namespace MovieSystem.Infrastructure.Presistance.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
     
          services.AddDbContext<MovieContext>(options =>options.UseSqlServer(configuration.GetConnectionString("MovieConnection")));
          services.AddScoped<IUnitOfWork,UnitOfWork>();
          services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
          services.AddScoped<IUserRepository, UserRepository>();
            //
            return services;
        }

        public static WebApplication UseInfrastructureServices(this WebApplication app)
        {
          
     
            return app;
        }
    }
}
