
[assembly: Microsoft.Owin.OwinStartup(typeof(ReportCard.Api.Server.Startup))]

namespace ReportCard.Api.Server
{
    using System.Web.Http;
    using Autofac.Integration.WebApi;
    using Microsoft.Owin.Cors;
    using Owin;
    using ReportCard.Api.Server.Applibs;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();
            app.UseWebApi(webApiConfiguration);

            app.UseCors(CorsOptions.AllowAll);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            //// API DI設定
            config.DependencyResolver = new AutofacWebApiDependencyResolver(AutofacConfig.Container);

            return config;
        }
    }
}
