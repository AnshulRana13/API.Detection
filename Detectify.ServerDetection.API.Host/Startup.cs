using Detectify.ServerDetection.API.Entities;
using Detectify.ServerDetection.API.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Detectify.ServerDetection.API.Web
{

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings.SetConfiguration(this.Configuration);
            services.AddAuthenticationServiceConfiguration();
            services.AddCorsPolicy();
            services.AddDependencyInjectionContainer();
            services.AddAppVersioning();
            services.AddSwaggerGen();
            services.AddSession();
            services.AddScaleoutDistributedCache(this.Configuration);
            services.AddControllers();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>      
        /// <param name="provider"></param> 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseCors(CorsConfigurationService.ALLOW_ALL_ORIGINS_POLICY);   
            app.UseHttpsRedirection();
            app.UseExceptionHandlerService();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });       
            app.UseSwaggerUI(provider);
        }
    }
}
