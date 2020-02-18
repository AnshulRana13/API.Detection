using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Detectify.ServerDetection.API.Provider;
using Detectify.ServerDetection.API.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Detectify.ServerDetection.API.Web.Middleware
{

    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjectionContainerService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencyInjectionContainer(this IServiceCollection services)
        {

            // Swagger 
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //Provider
            services.AddTransient<IAuthProvider, AuthProvider>();
            services.AddTransient<ICacheManager, RedisCacheManager>();
            services.AddTransient<IWebRequestHandler, WebRequestHandler>();
            services.AddTransient<IDnsDetailProvider, DnsDetailProvider>();
            //Repository
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
