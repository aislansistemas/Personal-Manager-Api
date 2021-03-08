
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PersonalManagement.Api.Contracts;
using PersonalManagement.Api.Repositories;
using PersonalManagement.Api.Repositories.Contracts;
using PersonalManagement.Api.Repository;

namespace PersonalManagement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IControlPointRepository, ControlPointRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }

    }
}