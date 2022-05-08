using Application.Activities;
using Application.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Photos;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.ServiceExtensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(
                // Add Authorization for all controllers
                opt =>
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    opt.Filters.Add(new AuthorizeFilter(policy));
                }
            )
            .AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Create>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
        }

        public static void AddApiCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
                });
            });
        }
    }
}