using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Unity.AspNet.WebApi;
using System.Web.Http;

[assembly: OwinStartup(typeof(Arf.WebApi.Startup))]

namespace Arf.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// Setup Unity
            //var resolver = new UnityDependencyResolver(UnityConfig.Container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;

            // Configure WebApi
            //GlobalConfiguration.Configure(config => 
            //{
            //    WebApiConfig.Register(config);
            //});

            //ConfigureAuth(app);
        }
    }
}
