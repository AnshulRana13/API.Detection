using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detectify.ServerDetection.API.Web.Middleware
{
    public static class AppVersioning
    {
        public static void AddAppVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
            config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;

                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}
