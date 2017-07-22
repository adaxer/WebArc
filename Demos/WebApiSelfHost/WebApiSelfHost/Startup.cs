using AutoMapper;
using Owin;
using System.Web.Http;

namespace WebApiSelfHost
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            ConfigureMapper();
        }

        private void ConfigureMapper()
        {
            Mapper.CreateMap<Category, CategoryDTO>()
                .ReverseMap();
//                .ForSourceMember(c => c.Picture, o => o.Ignore());
        }
    }
}