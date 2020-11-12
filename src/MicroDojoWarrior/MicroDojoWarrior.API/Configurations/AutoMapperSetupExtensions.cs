using AutoMapper;
using MicroDojoWarrior.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroDojoWarrior.API.Configurations
{
    public static class AutoMapperSetupExtensions
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            AutoMapperConfig.RegisterMappings();
        }
    }
}