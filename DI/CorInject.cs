using System;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class CorInject
    {
        public static void ConfigureServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var data = SettingUtility.Get<CorsSetting>("CorsSetting.json").Cors;
            services.AddCors(o => o.AddPolicy("Cors", builder => builder
           .WithOrigins(data)
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials()));
        }
    }
}
