using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MockRegister.Middleware
{
    public static  class SwaggerExtensions
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Payment",
                        Version = "v1",
                        Description = "Api for mock register payments",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Mock Register"
                        }
                    });

                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"MockRegister.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public static void SwaggerApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Api Mock Register");

                c.RoutePrefix = "docs";
            });
        }
    }
}
