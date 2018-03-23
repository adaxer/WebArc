using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelloMvcCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IService, Service>();
            //MvcServiceCollectionExtensions.AddMvc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IService service)
        {
            //#if DEBUG
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //#endif
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        //public void ConfigureDevelopment(IApplicationBuilder app)
        //{

        //}

        public void ConfigureStaticWeb(IApplicationBuilder app, IHostingEnvironment env, ILoggerProvider loggerProvider, IConfiguration config)
        {
            if (env.IsStaticWeb())
            {
                var title = config.GetValue<string>("AppTitle");
                loggerProvider.CreateLogger("StaticWeb").LogInformation($"Applikation {title} gestartet");
            }

            app.UseStaticFiles();
        }

    }
    public interface IService
    {
        void Work();
    }

    public class Service : IService
    {
        public void Work()
        {
            throw new System.NotImplementedException();
        }
    }

}

namespace Microsoft.AspNetCore.Hosting
{
    public static class CustomHostingEnvironmentExtensions
    {
        public static bool IsStaticWeb(this IHostingEnvironment hostingEnvironment) => hostingEnvironment.IsEnvironment("StaticWeb");
    }
}
