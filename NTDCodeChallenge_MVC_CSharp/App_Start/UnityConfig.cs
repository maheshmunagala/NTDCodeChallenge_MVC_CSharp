using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using NTDCodeChallenge_MVC_CSharp.Services;
using NTDCodeChallenge_MVC_CSharp.HelperClasses;

namespace NTDCodeChallenge_MVC_CSharp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<IPostsService, PostsService>();
        }
    }
}