using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Produtos
{
    public class DeletarProdutoUseCase : IDeletarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeletarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ApiResponse<object>> ExecuteAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto == null)
                return ApiResponse<object>.Fail("Produto não encontrado.");

            await _produtoRepository.DeleteAsync(produto);

            return ApiResponse<object>.Ok(
                null,
                "Produto removido com sucesso."
            );
        }
    }
}
