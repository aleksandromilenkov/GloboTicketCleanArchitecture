using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagment.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GloboTicket.TicketManagement.Identity.Models; // Your ApplicationUser model
using GloboTicket.TicketManagement.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GloboTicket.TicketManagement.Application.Contracts.Identity;

namespace GloboTicket.TicketManagment.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register GloboTicketDbContext for both application data (Events, Orders, etc.)
            // and Identity-related data (Users, Roles, etc.).
            services.AddDbContext<GloboTicketDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GloboTicketTicketManagementConnectionString")));

            // Register your repositories for application entities.
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Register Identity services with the modified DbContext
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GloboTicketDbContext>() // Use the same DbContext for Identity
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            // JWT Authentication configuration
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;
        }
    }
}
