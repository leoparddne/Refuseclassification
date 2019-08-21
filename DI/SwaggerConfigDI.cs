using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DI
{
    public class SwaggerConfigDI
    {
        public static void SwaggerDIInjectConfigureServices(IServiceCollection services, string xmlFile)
        {
            //TODO 自定义注册
            //注册swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = $"{xmlFile} Doc",
                    Description = "Restful API Document",
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, $"{xmlFile}.xml");
                c.IncludeXmlComments(xmlPath);
            });


        }
        public static void SwaggerDIConfigure(IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }
    }
}
