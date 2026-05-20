using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Produtos
{
    public class ObterProdutoPorIdUseCase : IObterProdutoPorIdUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObterProdutoPorIdUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ApiResponse<ProdutoResponse>> ExecuteAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto == null)
                return ApiResponse<ProdutoResponse>.Fail("Produto não encontrado.");

            return ApiResponse<ProdutoResponse>.Ok(produto);
        }
    }
}
