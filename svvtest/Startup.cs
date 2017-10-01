using System.Web.Http;
using Owin;

namespace svvtest
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }

        private static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "AllCustomers",
                routeTemplate: "customers",
                defaults: new { controller = "Customers", action = "Get" }
            );
        }
    }
}