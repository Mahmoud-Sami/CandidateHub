
using CandidateHub.Application.Services;
using CandidateHub.Domain.Interfaces;
using CandidateHub.Infrastructure.Data;
using CandidateHub.Infrastructure.Interceptors;
using CandidateHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .AddInterceptors(new AuditableEntitySaveChangesInterceptor()));


            builder.Services.AddScoped<CandidateService>();
            builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
