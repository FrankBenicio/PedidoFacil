using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Requests;
using PedidoFacil.Domain.Enums;
using PedidosApi.Application.Interfaces.UseCases;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PedidoFacil.API.Controllers
{
    [RoutePrefix("api/pedidos")]
    public class PedidosController : BaseApiController
    {
        private readonly IListarPedidosUseCase _listarPedidosUseCase;
        private readonly IObterPedidoPorIdUseCase _obterPedidoPorIdUseCase;
        private readonly ICriarPedidoUseCase _criarPedidoUseCase;
        private readonly IAtualizarStatusPedidoUseCase _atualizarStatusPedidoUseCase;

        public PedidosController(
            IListarPedidosUseCase listarPedidosUseCase,
            IObterPedidoPorIdUseCase obterPedidoPorIdUseCase,
            ICriarPedidoUseCase criarPedidoUseCase,
            IAtualizarStatusPedidoUseCase atualizarStatusPedidoUseCase)
        {
            _listarPedidosUseCase = listarPedidosUseCase;
            _obterPedidoPorIdUseCase = obterPedidoPorIdUseCase;
            _criarPedidoUseCase = criarPedidoUseCase;
            _atualizarStatusPedidoUseCase = atualizarStatusPedidoUseCase;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get([FromUri] PedidoStatus? status = null)
        {
            var response = await _listarPedidosUseCase.ExecuteAsync(status);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var response = await _obterPedidoPorIdUseCase.ExecuteAsync(id);

            if (!response.Success)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(CreatePedidoRequest request)
        {
            var response = await _criarPedidoUseCase.ExecuteAsync(request);

            if (!response.Success)
                return BadRequest(string.Join(" | ", response.Errors));

            return Ok(response);
        }

        [HttpPatch]
        [Route("{id:guid}/status")]
        public async Task<IHttpActionResult> PatchStatus(Guid id, UpdatePedidoStatusRequest request)
        {
            var response = await _atualizarStatusPedidoUseCase.ExecuteAsync(id, request);

            if (!response.Success)
                return BadRequest(string.Join(" | ", response.Errors));

            return Ok(response);
        }
    }
}