using StudentInformation.Repository.Concrete;
using StudentInformation.Repository.Interface;
using StudentInformation.Service.Concrete;
using StudentInformation.Service.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace StudentInformation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}