using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Produtos
{
    public class ListarProdutosUseCase : IListarProdutosUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutosUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ApiResponse<List<ProdutoResponse>>> ExecuteAsync()
        {
            var produtos = await _produtoRepository.ListAsync();
            var response = produtos.Select(x => (ProdutoResponse)x).ToList();
            return ApiResponse<List<ProdutoResponse>>.Ok(response);
        }
    }
}
