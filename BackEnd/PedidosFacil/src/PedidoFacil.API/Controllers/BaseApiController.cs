using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PedidoFacil.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected IEnumerable<string> GetErrors(ValidationResult result)
        {
            return result.Errors.Select(x => x.ErrorMessage);
        }
    }
}