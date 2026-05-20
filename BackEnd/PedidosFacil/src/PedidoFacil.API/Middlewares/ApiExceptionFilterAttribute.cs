using PedidoFacil.Application.Responses;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace PedidosApi.Api.Middlewares
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var response = ApiResponse<object>.Fail(context.Exception.Message);

            context.Response = context.Request.CreateResponse(
                HttpStatusCode.BadRequest,
                response);
        }
    }
}
