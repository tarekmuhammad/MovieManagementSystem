using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSystem.Application.Automapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Contracts.Service;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Validations;


namespace MovieSystem.Application.Configrations
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Validations
            services.AddScoped<IValidator<UserCreateDto>, UserValidation>();
            // Auto Mapper
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            services.AddAutoMapper(x => x.AddProfile(new MovieProfile()));
            services.AddAutoMapper(x => x.AddProfile(new CategoryProfile()));
            services.AddAutoMapper(x => x.AddProfile(new ReviewProfile()));

            services.AddAutoMapper(x => x.AddProfile(new RoleProfile()));
            services.AddAutoMapper(x => x.AddProfile(new UserProfile()));

            // Application Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IMovieService,MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReviewService, ReviewService>();
            //
            //
            //
            return services;
        }
    }
}
