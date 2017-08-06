using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System;
using Southwind.Interfaces;
using Southwind.BusinessLogic;
using Southwind.DataAccess;
using System.Data.Entity;

namespace Southwind.BLHost
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
            Action<DbContext> initAction = db =>
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.AutoDetectChangesEnabled = false;
            };
            container.RegisterType<DbContext, SouthwindContext>(new ContainerControlledLifetimeManager(), new InjectionConstructor(initAction));

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}