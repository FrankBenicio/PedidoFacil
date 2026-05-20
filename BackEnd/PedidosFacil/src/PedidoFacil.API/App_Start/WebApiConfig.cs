using PedidosApi.Api.Middlewares;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PedidoFacil.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
                       "http://localhost:4200",
                       "*",
                       "*");

            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ApiExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
