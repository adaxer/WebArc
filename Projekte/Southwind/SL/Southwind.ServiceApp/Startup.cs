using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Southwind.BusinessLayer.Objects;
using Southwind.Contracts.Interfaces;
using Southwind.DataAccess.Repositories;
using System;
using System.Data.Entity;

namespace Southwind.ServiceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));
            string connection = Configuration.GetSection("ConnectionStrings")["SouthwindConnection"];
            services.AddTransient<DbContext, SouthwindDb>(sp=>new SouthwindDb(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
