using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Requests;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PedidoFacil.API.Controllers
{
    [RoutePrefix("api/produtos")]
    public class ProdutosController : BaseApiController
    {
        private readonly IListarProdutosUseCase _listarProdutosUseCase;
        private readonly IObterProdutoPorIdUseCase _obterProdutoPorIdUseCase;
        private readonly ICriarProdutoUseCase _criarProdutoUseCase;
        private readonly IAtualizarProdutoUseCase _atualizarProdutoUseCase;
        private readonly IDeletarProdutoUseCase _deletarProdutoUseCase;

        public ProdutosController(
            IListarProdutosUseCase listarProdutosUseCase,
            IObterProdutoPorIdUseCase obterProdutoPorIdUseCase,
            ICriarProdutoUseCase criarProdutoUseCase,
            IAtualizarProdutoUseCase atualizarProdutoUseCase,
            IDeletarProdutoUseCase deletarProdutoUseCase)
        {
            _listarProdutosUseCase = listarProdutosUseCase;
            _obterProdutoPorIdUseCase = obterProdutoPorIdUseCase;
            _criarProdutoUseCase = criarProdutoUseCase;
            _atualizarProdutoUseCase = atualizarProdutoUseCase;
            _deletarProdutoUseCase = deletarProdutoUseCase;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await _listarProdutosUseCase.ExecuteAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var response = await _obterProdutoPorIdUseCase.ExecuteAsync(id);

            if (!response.Success)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(CreateProdutoRequest request)
        {
            var response = await _criarProdutoUseCase.ExecuteAsync(request);

            if (!response.Success)
                return BadRequest(string.Join(" | ", response.Errors));

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Put(Guid id, UpdateProdutoRequest request)
        {
            var response = await _atualizarProdutoUseCase.ExecuteAsync(id, request);

            if (!response.Success)
                return BadRequest(string.Join(" | ", response.Errors));

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var response = await _deletarProdutoUseCase.ExecuteAsync(id);

            if (!response.Success)
                return NotFound();

            return Ok(response);
        }
    }
}