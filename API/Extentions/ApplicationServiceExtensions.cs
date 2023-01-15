using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Extentions
{
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Add services to a WebApplicationBuilder container
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>( opt => opt.UseSqlite(config.GetConnectionString("DefaultConnection")) );
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}