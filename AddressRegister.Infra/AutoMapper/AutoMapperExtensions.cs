using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AddressRegister.Infra.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
