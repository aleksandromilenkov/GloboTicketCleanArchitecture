﻿using GloboTicket.TicketManagement.Api.Middlewares;
using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Api.Utility;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Identity;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder ConfigureServices(
            this WebApplicationBuilder builder)
        {
            // Add services for Swagger, Application, Infrastructure, Persistence, etc.
            AddSwagger(builder.Services);

            // Add other services
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            // Register MediatR and specify the assembly where your handlers are located
            builder.Services.AddMediatR(Assembly.GetAssembly(typeof(UpdateEventCommandHandler)));
            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder;
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Use Swagger in Development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();  // Enabling Swagger
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();  // Important: Ensure routing is enabled for Swagger to work

            // Authentication, Exception handling, CORS, Authorization middleware
            app.UseAuthentication();

            app.UseCustomExceptionsHandler();

            app.UseCors("Open");

            app.UseAuthorization();

            // Map controllers to endpoints
            app.MapControllers();

            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Define Swagger documentation
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GloboTicket Ticket Management API",
                });

                // You can add more configurations here if needed (e.g., for filters)
                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GloboTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }

}
