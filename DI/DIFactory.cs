using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TianLeCommon.Filter;

namespace DI
{
    public static class DIFactory
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //注入swagger
            SwaggerConfigDI.SwaggerDIInjectConfigureServices(services, "Refuseclassification");

            MysqlConfigDI.ConfigureServices(services, configuration);

            CorInject.ConfigureServices(services, configuration);

            FillterDI(services);
        }
        public static void Configure(IApplicationBuilder app)
        {
            //swagger
            SwaggerConfigDI.SwaggerDIConfigure(app);
            //跨域
            app.UseCors("Cors");
        }
        private static void FillterDI(IServiceCollection services)
        {
            services.AddMvcCore(x =>
            {
                //x.Filters.Add(new ValidFillter());
                x.Filters.Add(new RetFillter());
            });
        }
    }
}
