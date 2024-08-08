using BaseUnitOfWork.Application.Interfaces.IRepositories;
using BaseUnitOfWork.Application.Interfaces.IService;
using BaseUnitOfWork.Domain.Entities;
using BaseUnitOfWork.Infrastructure.Database.AppDbContext;
using BaseUnitOfWork.Infrastructure.Extensions.FluentValidationRules.Example;
using BaseUnitOfWork.Infrastructure.Repositories;
using BaseUnitOfWork.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseUnitOfWork.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfService, UnitOfService>();
            #region Validators
            services.AddScoped<IValidator<ExampleEntity>, ExampleValidator>();
            #endregion
            return services;
        }
    }
}
