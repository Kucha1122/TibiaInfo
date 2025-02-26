using System;
using Microsoft.Extensions.DependencyInjection;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Infrastructure.Handlers;
using TibiaInfo.Infrastructure.Mappers;
using TibiaInfo.Infrastructure.Repositories;
using TibiaInfo.Infrastructure.Services;
using TibiaInfo.Infrastructure.Settings;

namespace TibiaInfo.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //TibiaInfo.API
            //TibiaInfo.Infrastructure
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddSingleton<IJwtHandler,JwtHandler>();
        }
    }
}