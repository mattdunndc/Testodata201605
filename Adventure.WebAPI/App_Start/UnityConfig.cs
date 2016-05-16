using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using AutoMapper;
using Adventure.WebAPI.AutoMapper;

namespace Adventure.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var config = new MapperConfiguration(cfg => {

                cfg.AddProfile<AutoMapperConfigProfile>();
                ///cfg.CreateMap<Source, Dest>();
            });
            var mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}